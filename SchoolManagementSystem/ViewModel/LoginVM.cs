using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModel
{
    public class LoginVM
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email format!")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
    
}

