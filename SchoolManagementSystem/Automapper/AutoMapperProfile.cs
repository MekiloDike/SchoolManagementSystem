using AutoMapper;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
        }
    }
}
