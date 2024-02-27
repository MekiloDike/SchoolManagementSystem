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

        public List<Teacher>? Teachers { get; set; }
        public List<NonAcademic>? NonAcademicStaff{ get; set; }
        public List<Student>? Students { get; set; }  
            
        
    }
}
