using SchoolManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class NonAcademic
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Qualification? Qualification { get; set; }
        public Position? Position { get; set; }
        public Levels? Level { get; set; }


        [ForeignKey("Users")]
        public string? UserId { get; set; }
        public Users? Users { get; set; }

        [ForeignKey("School")]
        public string? SchoolId { get; set; }
        public School? School { get; set; }
    }
}
