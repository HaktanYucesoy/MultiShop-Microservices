using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Base;

namespace MultiShop.Catalog.Entities
{
    public class Product:BaseMongoEntity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int  ProductStock { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
