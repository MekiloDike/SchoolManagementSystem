using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.DTO
{
    public class GetAllUsersDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string?  Email { get; set; }
        public string? PhoneNo { get; set; }
        public AddressDto? UserAddress { get; set; }
    }

    public class AddressDto
    {
        public string? StreetName { get; set; }
        public string? LGA { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
