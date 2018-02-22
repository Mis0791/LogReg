using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class LogViewModel 
    {

        [Required]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}