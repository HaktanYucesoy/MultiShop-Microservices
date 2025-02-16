using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Exceptions.OrderDetail
{
    public class OrderDetailDomainNotFoundException:Exception
    {
        public OrderDetailDomainNotFoundException(int id) : base($"OrderDetail with id {id} is not found")
        {

        }

        public OrderDetailDomainNotFoundException(string extendedMessage) : base(extendedMessage)
        {
        }
    }
}
