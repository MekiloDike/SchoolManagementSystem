using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.DbContext
{
    public class DataSeeding
    {
        public static void SeedCourses(AppDBContext dbContext)
        {
            // Check if there are already courses in the database
            if (dbContext.Courses.Any())
            {
                return; // If there are courses, no need to seed again
            }

            // Add some sample courses
            var courses = new[]
            {
                new Course { CourseName = "Mathematics"},
                new Course { CourseName = "English"},
                new Course { CourseName = "Science"},
                new Course { CourseName = "Art"},
                new Course { CourseName = "Language"},
                new Course { CourseName = "History"},
                new Course { CourseName = "Social"},
                new Course { CourseName = "Technology"},
            // Add more courses as needed
            };

            // Add courses to the database
            dbContext.Courses.AddRange(courses);
            dbContext.SaveChanges();
        }
    }
}
