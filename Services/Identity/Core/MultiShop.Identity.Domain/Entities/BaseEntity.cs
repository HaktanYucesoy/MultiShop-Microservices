
namespace MultiShop.Identity.Domain.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }


    }

}
