using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DbContext;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class TeacherManagement : ITeacherManagement
    {
        private readonly AppDBContext _DbContext;
        public TeacherManagement(AppDBContext dbContext)
        {
            _DbContext = dbContext;
        }


        public async Task<ResponseDto> AddTeacher(CreateTeacherDto createTeacherDto)
        {
            //map CreateTeacherDto to teacher
            var teacher = new Teacher
            {
                SchoolName = createTeacherDto.SchoolName,
                Qualification = createTeacherDto.Qualification,
                Class = createTeacherDto.Class,
                Level = createTeacherDto.Level,
                UserId = createTeacherDto.UserId,
                SchoolId = createTeacherDto.SchoolId,
                CourseId = createTeacherDto.CourseId,
            };
            await _DbContext.Teachers.AddAsync(teacher);
            var save = await _DbContext.SaveChangesAsync();
            if (save > 0)
            {
                return new ResponseDto { IsSuccessful = true, Message = "Teacher added sucessfully" };
            }
            return new ResponseDto { IsSuccessful = false, Message = "Teacchers added successfully" };
        }

        public async Task DeleteTeacher(string deleteTeacherId)
        {
            var delete = await _DbContext.Teachers.FirstOrDefaultAsync(x => x.Id == deleteTeacherId);
            if (delete == null)
            {
                throw new Exception("Id not found");
            }
            _DbContext.Remove(delete);
            _DbContext.SaveChanges();
        }

        public async Task<List<GetTeacherDto>> GetAllTeacher()
        {
            var entities = await _DbContext.Teachers.ToListAsync();

            //create list to hold the mapped  entitied
            List<GetTeacherDto> list = new List<GetTeacherDto>();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    var courseEntity = _DbContext.Courses.FirstOrDefault(x => x.Id == entity.CourseId);
                    var schoolEntity = _DbContext.Schools.FirstOrDefault(x => x.Id == entity.SchoolId);
                    var userEntity = _DbContext.Users.FirstOrDefault(x => x.Id == entity.UserId);
                    var addressEntity = new Address();
                    if (userEntity != null)
                    {
                        addressEntity = _DbContext.Address.FirstOrDefault(x => x.Id == entity.Users.AddressId);
                    }

                    //map Teacher to TeacherDto
                    var teacherDto = new GetTeacherDto
                    {
                        CourseName = courseEntity.CourseName,
                        Class = entity.Class,
                        Qualification = entity.Qualification,
                        Level = entity.Level,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Age = userEntity.Age,
                        Email = userEntity.Email,
                        Gender = userEntity.Gender,
                        StreetName = addressEntity.StreetName,
                        LGA = addressEntity.LGA,
                        State = addressEntity.State,
                        Country = addressEntity.Country,
                        SchoolName = schoolEntity.SchoolName,
                        SchoolLocation = schoolEntity.Location,

                    };
                    list.Add(teacherDto);
                }
                return list;
            }
            return list;

        }

        public async Task<GetTeacherDto> GetTeacherById( string getTeacherId)
        {
           var entity =await _DbContext.Teachers.Include(x => x.Course).
                Include(x => x.School).
                Include(x => x.Users).ThenInclude(x => x.Address).
                FirstOrDefaultAsync(x => x.Id == getTeacherId);

            if (entity != null)
            {                
            return new GetTeacherDto();
            }
            //map teacher to teacherDto
            var teacherDto = new GetTeacherDto
            {
               CourseName = entity.Course.CourseName,
                Class = entity.Class,
                Qualification = entity.Qualification,
                Level = entity.Level,
                FirstName = entity.Users.FirstName,
                LastName = entity.Users.LastName,
                Age = entity.Users.Age,
                Email = entity.Users.Email,
                Gender = entity.Users.Gender,
                StreetName = entity.Users.Address.StreetName,
                LGA = entity.Users.Address.LGA,
                State = entity.Users.Address.State,
                Country = entity.Users.Address.Country,
                SchoolName = entity.School.SchoolName,
                SchoolLocation = entity.School.Location,
            };
            
            return teacherDto;
        }

        public async Task<ResponseDto> UpdateTeacher(UpdateTeacherDto UpdateTeacherDto, string updateTeacherId)
        {
            var entity = await _DbContext.Teachers.FirstOrDefaultAsync(x => x.Id == updateTeacherId);
            if (entity == null) 
            {
                throw new Exception("Teacher Id not found");
            }
            //replace old teacher id with the new teacher id
            entity.Qualification = UpdateTeacherDto.Qualification;
            entity.Level = UpdateTeacherDto.Level;
            entity.Class = UpdateTeacherDto.Class;
            entity.SchoolName = UpdateTeacherDto.SchoolName;
            
            _DbContext.Teachers.Add(entity);
            var isSaved = await _DbContext.SaveChangesAsync();
            if (isSaved > 0)
            {
            return new ResponseDto { IsSuccessful = true, Message = "teacher updated successfully" };
            }
            return new ResponseDto { IsSuccessful = false, Message = "teacher not updated successfully" };
        }



    }
}
