namespace MultiShop.Catalog.Aspects.ExceptionHandling
{
    public class DomainExceptionRegistery
    {
        private readonly Dictionary<Type, object> _exceptionMaps = new();

        public void RegisterExceptions<TDomain>(DomainExceptionMap<TDomain> map)
        {
            _exceptionMaps[typeof(TDomain)] = map;
        }

        public DomainExceptionMap<TDomain> GetExceptionMap<TDomain>()
        {
            return (DomainExceptionMap<TDomain>)_exceptionMaps[typeof(TDomain)];
        }
    }
}
