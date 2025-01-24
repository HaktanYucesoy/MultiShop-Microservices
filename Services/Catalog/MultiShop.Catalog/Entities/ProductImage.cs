using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage:BaseEntity
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string ProductID { get; set; }

        public Product Product { get; set; }
    }
}
