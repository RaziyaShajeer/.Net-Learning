namespace FoodOrderingSystem.Models
{
    public class Dishes
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string DishCategory { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string DishImage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
