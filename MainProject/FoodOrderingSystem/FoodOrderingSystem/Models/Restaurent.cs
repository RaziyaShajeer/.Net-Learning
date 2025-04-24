namespace FoodOrderingSystem.Models
{
    public class Restaurent
    {
        public int RestaurentID { get; set; }
        public string RestoName { get; set; }
        public string  RestoAddress { get; set; }
        public string RestoPhn { get; set; }
        public string RestoEmail { get; set; }
        public int UserID { get; set; }
        public string OpeningHours { get; set; }
        public string CuisineType { get; set; }

    }
}
