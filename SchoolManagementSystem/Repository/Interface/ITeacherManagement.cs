using SchoolManagementSystem.DTO;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface ITeacherManagement
    {
        public Task<ResponseDto> AddTeacher(CreateTeacherDto CreateTeacherDto);
        public Task<ResponseDto> UpdateTeacher(UpdateTeacherDto UpdateTeacherDto,string updateTeacherId);
        public Task DeleteTeacher(string deleteTeacherId);
        public Task<GetTeacherDto> GetTeacherById(string getTeacherId);
        public Task<List<GetTeacherDto>> GetAllTeacher();

    }
}
