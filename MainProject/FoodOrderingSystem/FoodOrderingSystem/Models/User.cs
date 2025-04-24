using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "FirstName  is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " LastName is required.")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = " Email is required.")]
        public string Email { get; set; }
        [Phone]
        [Required(ErrorMessage = " Phone is required.")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = " Password is required.")]
        public string Password { get; set; }
        public  Role { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
