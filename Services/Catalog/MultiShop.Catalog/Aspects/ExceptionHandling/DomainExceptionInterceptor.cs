using Castle.DynamicProxy;

namespace MultiShop.Catalog.Aspects.ExceptionHandling
{
    public class DomainExceptionInterceptor<TDomain> : IInterceptor
    {

        private readonly DomainExceptionMap<TDomain> _domainExceptionMap;

        public DomainExceptionInterceptor(DomainExceptionRegistery domainExceptionRegistery)
        {
            _domainExceptionMap=domainExceptionRegistery.GetExceptionMap<TDomain>();
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();

                if(invocation.Method.ReturnType.IsGenericType &&
                     (invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)))
                {
                    HandleAsyncMethod(invocation);
                }
            }

            catch (Exception)
            {
                throw GetDomainException(invocation.Method.Name);
            }
        }


        private void HandleAsyncMethod(IInvocation invocation)
        {
            var task = (Task)invocation.ReturnValue;
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    throw GetDomainException(invocation.Method.Name);
                }
            });
        }

        private Exception GetDomainException(string methodName)
        {
            Type exceptionType = methodName switch
            {
                "GetByIdAsync" => _domainExceptionMap.NotFoundException,
                "CreateAsync" => _domainExceptionMap.CreateFailedException,
                "UpdateAsync" => _domainExceptionMap.UpdateFailedException,
                "DeleteAsync" => _domainExceptionMap.DeleteFailedException,
                "GetAllAsync" => _domainExceptionMap.GetFailedException,
                _ => typeof(Exception)
            };

            return (Exception)Activator.CreateInstance(exceptionType)!;
        }
    }
}
