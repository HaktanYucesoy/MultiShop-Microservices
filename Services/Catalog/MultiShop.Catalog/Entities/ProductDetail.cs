using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Base;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail:BaseMongoEntity
    {
        public string ProductDescription { get; set; }

        public string ProductInfo { get; set; }

        public string ProductID { get; set; }

        public Product Product { get; set; }
    }
}
