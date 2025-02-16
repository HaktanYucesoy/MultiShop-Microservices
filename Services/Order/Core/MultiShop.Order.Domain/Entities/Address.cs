using MultiShop.Order.Domain.Common;

namespace MultiShop.Order.Domain.Entities
{
    public class Address:BaseEntity<int>
    {
        public string UserId { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Detail { get; private set; }

        private Address() { }

        public static Address Create(string userId, string district,
            string city, string detail)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId cannot be empty");

            return new Address
            {
                UserId = userId,
                District = district,
                City = city,
                Detail = detail
            };
        }
    }
}
