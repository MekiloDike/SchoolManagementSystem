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
        public Address? Address { get; set; }
        public string? Class { get; set; }
        public List<Teacher>? TeacherName { get; set; }

        [ForeignKey("Users")]
        public string? UserId { get; set; }
        public Users? Users { get; set; }

        [ForeignKey("School")]
        public string? SchoolId { get; set; }
        public School? School { get; set; }

        [ForeignKey("StudentCourse")]//many to many
        public string? StudentCourseId { get; set; }
        public StudentCourse? StudentCourse { get; set; }



    }
}
