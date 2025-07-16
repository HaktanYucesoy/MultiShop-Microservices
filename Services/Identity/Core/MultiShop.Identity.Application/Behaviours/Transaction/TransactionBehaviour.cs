using MediatR;
using MultiShop.Identity.Application.Common.Strategies.Failure.Factories;
using MultiShop.Identity.Application.Exceptions.CRUD;
using MultiShop.Identity.Application.Interfaces.UnitOfWork;

namespace MultiShop.Identity.Application.Behaviours.Transaction
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest, new()

    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFailureResponseStrategyFactory _strategyFactory;

        public TransactionBehaviour(IUnitOfWork unitOfWork, IFailureResponseStrategyFactory strategyFactory)
        {
            _unitOfWork = unitOfWork;
            _strategyFactory = strategyFactory;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!ShouldUseTransaction(request))
            {
                return await next();
            }

            return await ExecuteInTransactionAsync(next,cancellationToken);
        }

        private async Task<TResponse> ExecuteInTransactionAsync(RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = default(TResponse)!;
            System.Exception? capturedException = null;

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async (ct) =>
                {
                    try
                    {
                        response = await next();
                    }
                    catch (System.Exception ex)
                    {
                        capturedException = ex;
                        throw;

                    }
                },cancellationToken);
            }

            catch(EntityInsertFailedException entityInsertFailedException)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to insert entity:{entityInsertFailedException.Message}");
            }
            catch (EntityUpdateFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to update entity:{ex.Message}");
            }
            catch (EntityDeleteFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to delete entity:{ex.Message}");
            }
            catch (BaseEntityOperationFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Database operation failed:{ex.Message}");
            }
            catch (System.Exception ex) when (IsDatabaseRelated(ex))
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to delete entity:{ex.Message}");
            }

            return response;
        }

        private bool IsDatabaseRelated(System.Exception ex)
        {
            var exceptionType = ex.GetType();
            var exceptionName = exceptionType.Name.ToLowerInvariant();

            // Common database exception patterns
            var databaseExceptionIndicators = new[]
            {
            "sql", "database", "connection", "timeout", "constraint",
            "deadlock", "transaction", "concurrency", "entity"
        };

            return databaseExceptionIndicators.Any(indicator =>
                exceptionName.Contains(indicator) ||
                exceptionType.Namespace?.ToLowerInvariant().Contains(indicator) == true);
        }


        private bool ShouldUseTransaction(TRequest request)
        {
            if (request is INonTransactionalCommand)
            {
                return false;
            }

            if(request is ITransactionalCommand)
            {
                return true;
            }

            var requestType=typeof(TRequest);
            var isCommand=requestType.Name.Contains("Command",StringComparison.OrdinalIgnoreCase);
            var isQuery = requestType.Name.Contains("Query", StringComparison.OrdinalIgnoreCase);

            return isCommand && !isQuery;
        }
    }
}
