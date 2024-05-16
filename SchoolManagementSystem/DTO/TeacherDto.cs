using SchoolManagementSystem.Enum;

namespace SchoolManagementSystem.DTO
{
    public class CreateTeacherDto
    {
       
        public Levels? Level { get; set; }
        public Classes? Class { get; set; }
        public Qualification? Qualification { get; set; }
        public string? SchoolName { get; set; }
        public string? UserId { get; set; }
        public string? SchoolId { get; set; }
        public string? CourseId { get; set; }
    }  

    public class GetTeacherDto
    {
        public string CourseName { get; set; }
        public Qualification? Qualification { get; set; }
        public Levels? Level { get;set; }
        public Classes? Class { get; set;}      
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

    public class UpdateTeacherDto
    {
        public Qualification? Qualification { get; set; }
        public Levels? Level { get; set; }
        public Classes? Class { get; set; }
        public string? Email { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolLocation { get; set; }



    }
}
