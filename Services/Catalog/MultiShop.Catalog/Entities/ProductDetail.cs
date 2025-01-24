using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }

        public string ProductDescription { get; set; }

        public string ProductInfo { get; set; }

        public string ProductID { get; set; }

        public Product Product { get; set; }
    }
}
