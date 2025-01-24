namespace MultiShop.Catalog.Aspects.ExceptionHandling
{
    public class DomainExceptionMap<TDomain>
    {
        public Type NotFoundException { get; set; }
        public Type CreateFailedException { get; set; }
        public Type UpdateFailedException { get; set; }
        public Type DeleteFailedException { get; set; }
        public Type GetFailedException { get; set; }
    }
}
