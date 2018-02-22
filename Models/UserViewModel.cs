using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class UserViewModel 
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters and at least 2 characters")]
        public string FirstName { get; set; }
 
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters and at least 2 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Password must be at least 8 characters")]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string Passconf { get; set; }

    }
}