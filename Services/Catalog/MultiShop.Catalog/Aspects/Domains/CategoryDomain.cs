namespace MultiShop.Catalog.Aspects.Domains
{
    public sealed class CategoryDomain
    {
        private CategoryDomain() { } // Prevent instantiation
        public static CategoryDomain Instance { get; } = new();
    }
}
