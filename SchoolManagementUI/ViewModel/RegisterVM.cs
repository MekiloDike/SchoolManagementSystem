using System.ComponentModel.DataAnnotations;

namespace SchoolManagementUI.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [StringLength(20, ErrorMessage = "First name should not be more than 20 letters")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Last name should be between 2 to 20 letters", MinimumLength = 2)]
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number should be an eleven digit")]
        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email format!")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? StreetName { get; set; }
        [Required]
        public string? LGA { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}

