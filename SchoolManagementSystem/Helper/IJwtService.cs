using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Helper
{
    public interface IJwtService
    {
        string GenerateJwtToken(Users user);
    }
}
