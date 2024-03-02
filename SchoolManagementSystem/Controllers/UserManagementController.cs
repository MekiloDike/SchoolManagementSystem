using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Repository.Interface;
using SchoolManagementSystem.ViewModel;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        public UserManagementController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpPost]
        [Route("CreateNewUsers")]
        public async Task<IActionResult> UserRegister(RegisterUserVM registerUserVM)
        {
            try
            {
                var result = await _userManagement.RegisterUser(registerUserVM);
                if (result)
                    return Ok("User successfully registered");
                else
                    return BadRequest("failed to register user");
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("LogInUsers")]
        public async Task<IActionResult> LogIn(LoginVM loginVM)
        {
            try
            {
                var result = await _userManagement.LogInUser(loginVM);
                if (!string.IsNullOrEmpty(result))
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("LogOutusers")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _userManagement.LogOut();
                return Ok("Successfully loged out");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("GetAllAppUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userManagement.GetAllUsers();
                if (users is not null)
                    return Ok("Successful");
                else
                    return NotFound("No user found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
