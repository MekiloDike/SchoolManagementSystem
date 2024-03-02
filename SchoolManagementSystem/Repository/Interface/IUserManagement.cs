using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface IUserManagement
    {
        public Task<string> LogInUser(LoginVM Login);
        public Task<bool> RegisterUser(RegisterUserVM register);
        public Task LogOut();
        public Task<List<Users>> GetAllUsers();
    }
}
