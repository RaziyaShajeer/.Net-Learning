using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("Dish")]
public partial class Dish
{
    [Key]
    public Guid DishId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DishName { get; set; } = null!;

    [Unicode(false)]
    public string Description { get; set; } = null!;

    public byte[]? DishImage { get; set; }

    public int Category { get; set; }

    public int Availablity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Createdat { get; set; }

    public Guid RestaurantId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Price { get; set; }

    [InverseProperty("Dish")]
    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    [ForeignKey("RestaurantId")]
    [InverseProperty("Dishes")]
    public virtual RestaurantProfile Restaurant { get; set; } = null!;
}
