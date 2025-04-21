using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebMvc.Models.ViewModels
{
    [Keyless]
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
       

        public string Password { get; set; }
    }
}
