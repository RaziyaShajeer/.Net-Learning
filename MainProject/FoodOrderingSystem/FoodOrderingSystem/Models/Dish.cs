using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrderingSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("Dish")]
public partial class Dish
{
    [Key]
    public Guid DishId { get; set; } = Guid.NewGuid();

    [StringLength(50)]
    [Unicode(false)]
    public string DishName { get; set; } = null!;

    [Unicode(false)]
    public string Description { get; set; } = null!;


	[ForeignKey("category")]
	public Guid CategoryId { get; set; }

    public string DishImagePath { get;set; }    
	public DishAvailability Availablity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Createdat { get; set; } = DateTime.Now;
    public DishType dishType { get; set; }
    public Guid RestaurantId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [InverseProperty("Dish")]
    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    [ForeignKey("RestaurantId")]
    [InverseProperty("Dishes")]
    public virtual RestaurantProfile Restaurant { get; set; } = null!;
	public virtual Category category { get; set; }

}
