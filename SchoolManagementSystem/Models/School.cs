using SchoolManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class School
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? SchoolName { get; set; }
        public string? SchoolEmail { get; set; }
        public string? SchoolPhoneNumber { get; set; }
        public string? Location { get; set; }
        public SchoolType? SchoolType { get; set; }

        public List<Teacher>? Teachers { get; set; } = new List<Teacher>();
       // public List<NonAcademic>? NonAcademicStaff{ get; set; } = new List<NonAcademic>();
        public List<Student>? Students { get; set; } = new List<Student>();
      /*  public School()
        {
            Students = new List<Student>();
            Id = Guid.NewGuid().ToString();
        }*/
        
    }
}
