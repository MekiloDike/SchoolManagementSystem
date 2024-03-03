using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface IUserManagement
    {
        public Task<string> LogInUser(LoginDto Login);
        public Task<bool> RegisterUser(RegisterUserDto register);
        public Task LogOut();
        
    }
}
