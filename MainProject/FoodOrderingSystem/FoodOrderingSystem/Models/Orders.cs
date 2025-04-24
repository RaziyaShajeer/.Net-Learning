namespace FoodOrderingSystem.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int UserID { get; set; }
        public int RestaurantID { get; set; }
        public string Status { get; set; }           
        public string DeliveryTime { get; set; }     
        public string DeliveryAgent { get; set; }    
    }
}
