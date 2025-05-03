using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("Cartitem")]
public partial class Cartitem
{
    [Key]
    public Guid CartItemId { get; set; }

    public Guid Cartid { get; set; }

    public Guid DishId { get; set; }

    public int Quanity { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    [ForeignKey("DishId")]
    [InverseProperty("Cartitems")]
    public virtual Dish Dish { get; set; } = null!;
}
