using MediatR;
using MultiShop.Identity.Application.Common;
using MultiShop.Identity.Application.Common.Strategies.Failure.Factories;
using MultiShop.Identity.Application.Exceptions.CRUD;

namespace MultiShop.Identity.Application.Behaviours.Exception
{
    public class ExceptionHandlingBehaviour<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        #region previous Code
        //public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await next();
        //    }

        //    catch(EntityNotFoundException entityNotFoundException)
        //    {
        //       return HandleEntityNotFoundException(entityNotFoundException);
        //    }

        //    catch(EntityInsertFailedException entityInsertFailedException)
        //    {
        //        return HandleEntityInsertException(entityInsertFailedException);
        //    }

        //    catch(EntityUpdateFailedException entityUpdateFailedException)
        //    {
        //        return HandleEntityUpdateFailedException(entityUpdateFailedException);
        //    }

        //    catch(EntityDeleteFailedException entityDeleteFailedException)
        //    {
        //        return HandleEntityDeleteFailedException(entityDeleteFailedException);
        //    }

        //    catch(BaseEntityOperationFailedException baseEntityOperationFailedException)
        //    {
        //        return HandleBaseEntityOperationFailedException(baseEntityOperationFailedException);
        //    }

        //    catch(Exception generalException)
        //    {
        //       return HandleGeneralException(generalException);
        //    }
        //}

        //private TResponse HandleEntityNotFoundException(EntityNotFoundException entityNotFoundException)
        //{
        //    if (typeof(TResponse).GetInterfaces().Contains(typeof(IHandleUserNotFound)))
        //    {
        //        return CreateFailureResponse(UserMessages.USER_VALIDATION_FAILED);

        //    }

        //    return CreateFailureResponse($"Entity not found:{entityNotFoundException.Message}");
        //}
        //private TResponse HandleEntityDeleteFailedException(EntityDeleteFailedException entityDeleteFailedException)
        //{
        //    return CreateFailureResponse($"Failed to delete entity:{entityDeleteFailedException.Message}" );
        //}

        //private TResponse HandleEntityUpdateFailedException(EntityUpdateFailedException entityUpdateFailedException)
        //{
        //    return CreateFailureResponse($"Failed to update entity:{entityUpdateFailedException.Message}");
        //}

        //private TResponse HandleEntityInsertException(EntityInsertFailedException entityInsertFailedException)
        //{
        //    return CreateFailureResponse($"Failed to insert entity:{entityInsertFailedException.Message}");
        //}
        //private TResponse HandleBaseEntityOperationFailedException(BaseEntityOperationFailedException baseEntityOperationFailedException)
        //{
        //    return CreateFailureResponse($"Database operation failed:{baseEntityOperationFailedException.Message}");
        //}

        //private TResponse HandleGeneralException(Exception generalException)
        //{
        //    return CreateFailureResponse($"An unexpected error occured:{generalException.Message}");
        //}


        //private TResponse CreateFailureResponse(string message)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion


        private readonly IFailureResponseStrategyFactory _strategyFactory;

        public ExceptionHandlingBehaviour(IFailureResponseStrategyFactory failureResponseStrategyFactory)
        {
            _strategyFactory = failureResponseStrategyFactory;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (EntityNotFoundException ex)
            {
                return HandleEntityNotFoundException(ex);
            }
            catch (EntityInsertFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to create entity: {ex.Message}");
            }
            catch (EntityUpdateFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to update entity: {ex.Message}");
            }
            catch (EntityDeleteFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Failed to delete entity: {ex.Message}");
            }
            catch (BaseEntityOperationFailedException ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Database operation failed: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"An unexpected error occurred: {ex.Message}");
            }
        }

        private TResponse HandleEntityNotFoundException(EntityNotFoundException ex)
        {
            if (typeof(TResponse).GetInterfaces().Contains(typeof(IHandleUserNotFound)))
            {
                return _strategyFactory.CreateFailureResponseStrategic<TResponse>("User validation failed");
            }

            return _strategyFactory.CreateFailureResponseStrategic<TResponse>($"Entity not found: {ex.Message}");
        }
    }
}
