using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwtAuth.Data.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
