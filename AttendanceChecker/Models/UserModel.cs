using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AttendanceChecker.Models
{
    public class UserModel
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public Boolean IsAdmin { get; set; }

    }

}
