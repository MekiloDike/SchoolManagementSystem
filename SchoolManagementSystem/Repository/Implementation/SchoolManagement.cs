using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Repository.Interface;
using SchoolManagementSystem.DbContext;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System.Diagnostics.Eventing.Reader;
//using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class SchoolManagement : ISchoolManagement
    {

        private readonly AppDBContext _dbContext;
        public SchoolManagement(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto> CreateSchool(SchoolDto schoolDto)
        {
            //map SchoolDto to school model
            var school = new School
            {
                SchoolName = schoolDto.SchoolName,
                SchoolEmail = schoolDto.SchoolEmail,
                SchoolPhoneNumber = schoolDto.SchoolPhoneNumber,
                Location = schoolDto.Location,
            };
            //add school
            await _dbContext.Schools.AddAsync(school);
            //save school
            var saved = await _dbContext.SaveChangesAsync();
            if (saved > 0)
            {
                return new ResponseDto { IsSuccessful = true, Message = "School created successfuly", Id = school.Id };
            }
            return new ResponseDto { IsSuccessful = false, Message = "School created not successfuly" };
        }


        public async Task DeleteSchool(string id)
        {
            var entity = await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception("id not found");
            }
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetSchoolDto>> GetAllSchool()
        {
            List<GetSchoolDto> list = new List<GetSchoolDto>();
            var entities = await _dbContext.Schools.ToListAsync();
            if (entities is not null)
            {
                foreach (var entity in entities)
                {
                    //map school to schoolDto
                    var schoolDto = new GetSchoolDto
                    {
                        Id = entity.Id,
                        SchoolEmail = entity.SchoolEmail,
                        Location = entity.Location,
                        SchoolName = entity.SchoolName,
                        SchoolPhoneNumber = entity.SchoolPhoneNumber,
                    };
                    list.Add(schoolDto);
                }
                return list;
            }

            return list;
        }


        public async Task<GetSchoolDto> GetSchoolById(string schoolId)
        {

            var entity = await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == schoolId);
            if (entity == null)
            {
                return null;
            }
            //map school model to schoolDto
            var schoolDto = new GetSchoolDto
            {
                Id=entity.Id,
                SchoolName = entity.SchoolName,
                SchoolEmail = entity.SchoolEmail,
                SchoolPhoneNumber = entity.SchoolPhoneNumber,
                Location = entity.Location,
                //  Teachers = new List<Teacher>(),
                // Students = new List<Student>(),           
            };
            return schoolDto;

        }

        public async Task<ResponseDto> UpdateSchool(SchoolDto schoolDto, string schoolId)
        {
            var entity = await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == schoolId);
            if (entity == null)
            {
                return new ResponseDto() { IsSuccessful = false, Message = $"School with Id: {schoolId} not found" };
            }
            //map the new school update to the old update
            entity.SchoolPhoneNumber = schoolDto.SchoolPhoneNumber;
            entity.Location = schoolDto.Location;
            entity.SchoolName = schoolDto.SchoolName;
            entity.SchoolEmail = schoolDto.SchoolEmail;

            _dbContext.Schools.Update(entity);

            var Saved = await _dbContext.SaveChangesAsync() > 0;
            if (Saved)
            {
                return new ResponseDto { IsSuccessful = true, Message = "successful" };

            }

            return new ResponseDto { IsSuccessful = false, Message = "not successful" };

        }

    }


}
