using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebMvc.Models.ViewModels
{
    [Keyless]
    public class RegisterViewModel
    {
        public string Role { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
       

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }

    }
}
