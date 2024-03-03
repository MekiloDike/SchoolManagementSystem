using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Interface
{
    public interface IAdminManagement
    {
        public Task<List<GetAllUsersDTO>> GetAllUsers();
        public Task<CreateRoleResponse> CreateUserRole(string userRole);
        public Task<CreateRoleResponse> AssignUserRole(string userId, string roleId);
        
    }
}
