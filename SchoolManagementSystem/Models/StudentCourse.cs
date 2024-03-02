using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class StudentCourse
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Course>? Course { get; set; } = new List<Course>();
        public List<Student>? Students { get; set; } = new List<Student>();
    }
}
