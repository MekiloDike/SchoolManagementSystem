using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Address
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? StreetName { get; set; }
        public string? LGA { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public Users? User { get; set; }
    }
}
