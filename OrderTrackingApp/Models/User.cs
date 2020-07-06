using System.Collections.Generic;

namespace OrderTrackingApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; }
    }
}
