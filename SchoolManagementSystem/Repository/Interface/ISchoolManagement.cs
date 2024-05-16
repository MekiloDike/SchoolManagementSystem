using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface ISchoolManagement
    {
       public Task<ResponseDto> CreateSchool(SchoolDto schoolDto);
        public Task<ResponseDto> UpdateSchool(SchoolDto schoolDto, string schoolId);
        public Task DeleteSchool(string schoolId);                                
        public Task<GetSchoolDto> GetSchoolById(string schoolId);
        public Task<List<GetSchoolDto>> GetAllSchool();
        
    }
}
