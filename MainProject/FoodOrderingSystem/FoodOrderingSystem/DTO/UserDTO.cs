using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.DTO
{
    public class UserDTO
    {
        
        public Guid UserId { get; set; }= Guid.NewGuid();
        public string FirstName { get; set; } 
        public string? Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public String LocationName { get; set; }
        //public IEnumerable<SelectListItem>Locations { get; set; }
        
    }
}
