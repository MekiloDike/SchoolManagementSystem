using SchoolManagementSystem.DTO;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface IStudentManagement
    {
       // public  string GenerateRegistrationNumber(string className);
        public Task<ResponseDto> AddStudent(CreateStudentDto studentDto);
        public Task<ResponseDto> UpdateStudent(UpdateStudentDto studentDto, string updateStudentId);
        public Task DeleteStudent(string deleteStudentId);
        public Task<StudentDto> GetStudentById(string getStudentId);
        public Task<List<StudentDto>> GetAllStudent();

    }
}
