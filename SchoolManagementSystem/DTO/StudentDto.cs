using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.DTO
{
    public class CreateStudentDto
    {
              
        public string? GuidianName { get; set; }
        //public Address? Address { get; set; }
        public Classes Class { get; set; }
        //public string? RegNo { get; set; }
        public string? UserId { get; set; }
        public string? SchoolId { get; set; }
        public List<string>? CourseIds { get; set; }

    }
    public class UpdateStudentDto
    {
              
        public string? GuidianName { get; set; }
        public string? Class { get; set; }
        public string? RegNo { get; set; }

    }
    public class StudentDto
    {
              
        public string? StudentId { get; set; }
        public string? GuidianName { get; set; }
        public string? Class { get; set; }
        public string? RegNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? StreetName { get; set; }
        public string? LGA { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolLocation { get; set; }

    }
}
