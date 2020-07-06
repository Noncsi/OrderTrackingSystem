using System.Collections.Generic;

namespace OrderTrackingApp.Models
{
    public class Order
    {
        public string Id { get; set; }
        public OrderStatus Status { get; set; }

        public IList<OrderCart> Cart { get; set; }
    }
}
