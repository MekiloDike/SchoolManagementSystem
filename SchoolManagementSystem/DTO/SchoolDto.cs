using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.DTO
{
    public class SchoolDto
    {
        public string? SchoolName { get; set; }
        public string? SchoolEmail { get; set; }
        public string? SchoolPhoneNumber { get; set; }
        public string? Location { get; set; }
        public SchoolType? SchoolType { get; set; }


    }
    public class GetSchoolDto
    {
        public string? Id { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolEmail { get; set; }
        public string? SchoolPhoneNumber { get; set; }
        public string? Location { get; set; }
        public SchoolType? SchoolType { get; set; }

    }


}

