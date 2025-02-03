namespace MultiShop.Catalog.Aspects.ExceptionHandling
{
    public class DomainExceptionRegistery
    {
        private readonly Dictionary<Type, object> _exceptionMaps = new();

        public void RegisterExceptions<TDomain>(DomainExceptionMap<TDomain> map)
        {
            _exceptionMaps.Add(typeof(TDomain), map);
        }

        public virtual DomainExceptionMap<TDomain> GetExceptionMap<TDomain>()
        {
            var val=(DomainExceptionMap<TDomain>)_exceptionMaps[typeof(TDomain)];
            return val;
        }

      
    }
}
