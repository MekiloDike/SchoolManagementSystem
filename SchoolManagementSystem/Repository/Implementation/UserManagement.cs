using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.ViewModel;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Interface;
using SchoolManagementSystem.Helper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DTO;
using System.Data;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class UserManagement : IUserManagement
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IJwtService _ijwtService;
        public UserManagement(UserManager<Users> userManager, SignInManager<Users> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ijwtService = jwtService;
        }
        public async Task<bool> RegisterUser(RegisterUserDto register)
        {
            var existingUser = await _userManager.FindByEmailAsync(register.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var userModel = new Users
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Gender = register.Gender,
                PhoneNumber = register.PhoneNumber,
                UserName = register.Email,
                Address = new Address
                {
                    StreetName = register.StreetName,
                    LGA = register.LGA,
                    State = register.State,
                    Country = register.Country,

                },
            };
            userModel.AddressId = userModel.Address.Id;

            var result = await _userManager.CreateAsync(userModel, register.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userModel, isPersistent: false);
            }
            return result.Succeeded;
        }

        public async Task<string> LogInUser(LoginDto login)
        {
            var token = "";
            var userModel = await _userManager.FindByNameAsync(login.Email);
            if (userModel == null)
            {
                throw new Exception("user does not exist");
            }

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(userModel, login.Password, false);
            if (!checkPassword.Succeeded)
            {
                throw new Exception("password incorrect");
            }

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //get all the roles of that user
                var userRole = await _userManager.GetRolesAsync(userModel);
                token = _ijwtService.GenerateJwtToken(userModel, userRole);
            }
            return token;
        }


        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

       
    }
}
