using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Interface;
using System.Data;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class AdminManagement : IAdminManagement
    {
        private readonly UserManager<Users> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminManagement(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<GetAllUsersDTO>> GetAllUsers()
        {
            List<GetAllUsersDTO> list = new List<GetAllUsersDTO>();
            var users = await _userManager.Users.Include(x => x.Address).ToListAsync();
            if(users is not null)
            {
                foreach (var user in users)
                {
                    //map users to GetAllUsersDto
                    var userDto = new GetAllUsersDTO
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber,
                        Age = user.Age,
                        Gender = user.Gender,
                        UserAddress = new AddressDto
                        {
                            State = user.Address.State,
                            Country = user.Address.Country,
                            LGA = user.Address.LGA,
                            StreetName = user.Address.StreetName,
                        }

                    };
                    list.Add(userDto);

                }
                return list;

            }
            return list;
        }
      
        public async Task<CreateRoleResponse> CreateUserRole(string userRole)
        {
            //check if role exist
            var doesRoleExist = await _roleManager.RoleExistsAsync(userRole);
            if (doesRoleExist)
            {
                return new CreateRoleResponse()
                {
                    IsSuccessful = false,
                    Message = "role doesnt exist",
                };
            }
            // role does not exist, so create it        
            var newRole = new IdentityRole(userRole);
            var result = await _roleManager.CreateAsync(newRole);

            //check if role creating succeeded
            if (result.Succeeded)
            {
                return new CreateRoleResponse
                {
                    IsSuccessful = true,
                    Message = "role created"
                };
            }
            else
            {
                return new CreateRoleResponse { IsSuccessful = false, Message = $"role not created {result.Errors}" };
            }
        }

        public async Task<CreateRoleResponse> AssignUserRole(string userId, string roleId)
        {
            //check if user exist
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return new CreateRoleResponse { IsSuccessful = false, Message = "user does not exist" };
            }

            // check if role exist
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                return new CreateRoleResponse { IsSuccessful = false, Message = "role does not exist" };

            }

            //check if user already have that role
            var userRoleExist = await _userManager.IsInRoleAsync(user, role.Name);

            if (userRoleExist)
            {
                return new CreateRoleResponse { IsSuccessful = false, Message = "user already have the role" };
            }

            //assign role to user
            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return new CreateRoleResponse { IsSuccessful = true, Message = "role successfully asigned to user" };
            }
            else
            {
                return new CreateRoleResponse { IsSuccessful = false, Message = $"Failed to assign role to user: {result.Errors}" };
            }
        }
    }
}
