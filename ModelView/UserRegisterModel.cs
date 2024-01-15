using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.ModelView
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Users Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int age{ get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Image is required")]
        public IFormFile img { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$", ErrorMessage ="Password Error")]
        public string Password { get; set; }
        [Compare("Password" , ErrorMessage =("Password not ConFirm"))]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
    }
}
