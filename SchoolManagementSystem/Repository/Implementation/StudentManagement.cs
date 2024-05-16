using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DbContext;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class StudentManagement : IStudentManagement
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<StudentManagement> _logger;
        private readonly IMapper _mapper;
        public StudentManagement(AppDBContext dbContext, ILogger<StudentManagement> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }
        //serilog ()
        public string GenerateRegistrationNumber(string className)
        {
            // Generate a random number between 10000 and 99999
            _logger.LogInformation("About to generate reg number for: ", className);
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);

            // Generate two random letters
            char randomLetter1 = (char)random.Next('A', 'Z' + 1);
            char randomLetter2 = (char)random.Next('A', 'Z' + 1);
            var year = DateTime.Now.Year;

            // Combine class name, and random number to form registration number
            string registrationNumber = $"{className}/{year}/{randomNumber}{randomLetter1}{randomLetter2}";
            _logger.LogInformation("reg number generated: ", registrationNumber);
            return registrationNumber;
        }


        public async Task<ResponseDto> AddStudent(CreateStudentDto studentDto)
        {

            var generateRegNo = GenerateRegistrationNumber(studentDto.Class.ToString());

            //map studentDTO to student
            var student1 = _mapper.Map<Student>(studentDto);

            var student = new Student
            {
                GuidianName = studentDto.GuidianName,
                Class = studentDto.Class.ToString(),
                UserId = studentDto.UserId,
                SchoolId = studentDto.SchoolId,
                RegNo = generateRegNo,
            };

           
            //create relationship between courses and students using the courseId passed
            var studentCourseList = new List<StudentCourse>();

            foreach (var courseId in studentDto.CourseIds)
            {
                var studentCourse = new StudentCourse
                {
                    CourseId = courseId,
                    StudentId = student.Id
                };
                studentCourseList.Add(studentCourse);
            }

            //update the student table
            student.StudentCourse = studentCourseList;

            await _dbContext.Students.AddAsync(student);
            var saved = await _dbContext.SaveChangesAsync();
            if (saved > 0)
            {
                return new ResponseDto { IsSuccessful = true, Message = "student added successfuly", Id = student.Id };

            }

            return new ResponseDto { IsSuccessful = false, Message = "student not added successfuly" };
        }

        public async Task DeleteStudent(string deleteStudentId)
        {
            var delete = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == deleteStudentId);
            if (delete == null)
            {
                throw new Exception("id not found");
            }
            _dbContext.Remove(delete);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<StudentDto>> GetAllStudent()
        {
            //create list to hold the mapped entities
            List<StudentDto> list = new List<StudentDto>();

            var entities = await _dbContext.Students
                .Include(x => x.Users).ThenInclude(u => u.Address)
                .Include(x => x.School).ToListAsync();

            if (entities is not null)
            {
                //loop through and map
                foreach (var entity in entities)
                {
                    //var userEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == entity.UserId);
                    //var schoolEntity = await _dbContext.Schools.FirstOrDefaultAsync(s => s.Id == entity.SchoolId);
                    //var addressEntity = new Address();
                    //if (userEntity != null)
                    //{
                    //    addressEntity = await _dbContext.Address.FirstOrDefaultAsync(a => a.Id == userEntity.AddressId);
                    //}
                    //var addressEntity = await _dbContext.Address.FirstOrDefaultAsync(a => a.Id == entity.Users.AddressId);
                    
                    //map student to studentDto
                    var studentDto1 = _mapper.Map<StudentDto>(entity);

                    var studentDto = new StudentDto
                    {
                        GuidianName = entity.GuidianName,
                        RegNo = entity.RegNo,
                        Class = entity.Class,
                        StudentId = entity.Id,
                        FirstName = entity.Users?.FirstName == null ? null : entity.Users?.FirstName,
                        LastName = entity.Users?.LastName,
                        Age = entity.Users == null ? 0 : entity.Users.Age,
                        Email = entity.Users?.Email,
                        Gender = entity.Users?.Gender,
                        StreetName = entity.Users?.Address?.StreetName,
                        LGA = entity.Users?.Address?.LGA,
                        State = entity.Users?.Address?.State,
                        Country = entity?.Users?.Address?.Country,
                        SchoolName = entity?.School?.SchoolName,
                        SchoolLocation = entity?.School?.Location,


                    };
                    list.Add(studentDto);
                }
                return list;
            }
            return list;
        }

        public async Task<StudentDto> GetStudentById(string getStudentId)
        {
            var entity = await _dbContext.Students
                .Include(x => x.Users)
                .ThenInclude(u => u.Address)
                .Include(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == getStudentId);
            if (entity != null)
            {
                return new StudentDto();
            }


            //map student to studentDto
            var studentDto = new StudentDto
            {
                GuidianName = entity.GuidianName,
                RegNo = entity.RegNo,
                Class = entity.Class,
                StudentId = entity.Id,
                FirstName = entity.Users?.FirstName,
                LastName = entity.Users?.LastName,
                Age = entity.Users == null ? 0 : entity.Users.Age,
                Email = entity.Users?.Email,
                Gender = entity.Users?.Gender,
                StreetName = entity.Users?.Address?.StreetName,
                LGA = entity.Users?.Address?.LGA,
                State = entity.Users?.Address?.State,
                Country = entity.Users?.Address?.Country,
                SchoolName = entity.School?.SchoolName,
                SchoolLocation = entity.School?.Location,
            };

            return studentDto;
        }

        public async Task<ResponseDto> UpdateStudent(UpdateStudentDto studentDto, string updateStudentId)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == updateStudentId);
            if (entity == null)
            {
                return new ResponseDto { IsSuccessful = false, Message = "student id not found" };
            }
            //map the old student to the new student
            entity.RegNo = studentDto.RegNo;
            entity.Class = studentDto.Class;
            entity.GuidianName = studentDto.GuidianName;
            /*entity.Users.FirstName = studentDto.Users.FirstName;
            entity.Users.LastName = studentDto.Users.LastName;
*/
              _dbContext.Students.Update(entity);
            var Saved = await _dbContext.SaveChangesAsync() > 0;
            if (Saved)
            {
                return new ResponseDto { IsSuccessful = true, Message = "updated successfully" };

            }

            return new ResponseDto { IsSuccessful = false, Message = "failed to update" };

        }

    }
}
