using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? GuidianName { get; set; }
        public string? RegNo { get; set; }
        public string? Class { get; set; }

        //one to one
        [ForeignKey("Users")]
        public string? UserId { get; set; }
        public virtual Users? Users { get; set; } //virtual keyword is for eager loading

        //one to one
        [ForeignKey("School")]
        public string? SchoolId { get; set; }
        public virtual School? School { get; set; }
        //many to many
        public virtual List<StudentCourse>? StudentCourse { get; set; } = new List<StudentCourse> ();     
        
    }
}
