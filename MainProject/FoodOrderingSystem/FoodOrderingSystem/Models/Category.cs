﻿namespace FoodOrderingSystem.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
