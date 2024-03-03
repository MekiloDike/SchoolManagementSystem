using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Repository.Implementation;
using SchoolManagementSystem.Repository.Interface;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminManagementController : Controller
    {
        private readonly IAdminManagement _adminRepo;
        public AdminManagementController(IAdminManagement adminRepo) 
        { 
            _adminRepo = adminRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllAppUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _adminRepo.GetAllUsers();
                if (users is not null)
                    return Ok(users);
                else
                    return NotFound("No user found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Create-New-Role")]
        public async Task<IActionResult> CreatUserRole([FromQuery] string userRole)
        {
            try
            {
                var result = await _adminRepo.CreateUserRole(userRole);
                if (result.IsSuccessful)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AssignRoleToUser")]
        public async Task<IActionResult> AssignUserRole(string userId, string roleId)
        {
            try
            {
                var assignRoles = await _adminRepo.AssignUserRole(userId, roleId);
                if (assignRoles.IsSuccessful)
                {
                    return Ok(assignRoles);
                }
                else
                {
                    return BadRequest(assignRoles);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
