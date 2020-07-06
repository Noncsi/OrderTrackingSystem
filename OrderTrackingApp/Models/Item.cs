using System.Collections.Generic;

namespace OrderTrackingApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<OrderCart> Cart { get; set; }
    }
}
