using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class StudentCourse
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Course>? Course { get; set; }
        public List<Student>? Students { get; set; }
    }
}
