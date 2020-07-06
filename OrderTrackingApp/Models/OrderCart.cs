namespace OrderTrackingApp.Models
{
    public class OrderCart
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
