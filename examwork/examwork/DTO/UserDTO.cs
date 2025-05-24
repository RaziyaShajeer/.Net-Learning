using examwork.Enums;

namespace examwork.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        
        public int Age { get; set; }

        public string password { get; set; } 
    }
}
