using SchoolManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();      
        public Levels? Level { get; set; }
        public Qualification? Qualification { get; set; }
        public string? SchoolName { get; set; }
        public Classes? Class { get; set; }//use this to find all students
        

        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("School")]
        public string? SchoolId { get; set; }
        public School? School { get; set; }       

        [ForeignKey("Users")]
        public string? UserId {  get; set; }     
        public Users? Users { get; set; } 
       
    }


}
