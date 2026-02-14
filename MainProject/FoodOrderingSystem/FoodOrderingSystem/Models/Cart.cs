using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    public Guid CartId { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
  public virtual MyUser User { get; set; } = null!;
	public ICollection<Cartitem> CartItems { get; set; } = new List<Cartitem>();
}
