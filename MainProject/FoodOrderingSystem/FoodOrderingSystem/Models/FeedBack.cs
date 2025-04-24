namespace FoodOrderingSystem.Models
{
    public class FeedBack
    {
        public int FeedbackID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime? DateofFeedback { get; set; }

        public int UserID { get; set; }
        public int RestaurentID { get; set; }

        public int OrderID { get; set; }
       
    }
}
