namespace FoodOrderingSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
