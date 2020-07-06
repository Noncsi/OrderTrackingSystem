
using System.ComponentModel.DataAnnotations;

namespace OrderTrackingApp.Models
{
    public class Authentication
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}