
using System.ComponentModel.DataAnnotations;
using examwork.Enums;

namespace examwork.Models
{
    public class student
    {
        [Key]
        public  Guid  Id { get; set; }
        public string Name { get; set; }    
        public Role Role { get; set; }
        public int Age { get; set; }

        public string password { get; set; } = null!;


    }
}
