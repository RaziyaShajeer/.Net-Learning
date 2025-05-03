using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    public Guid CartId { get; set; }

    public Guid UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalAmount { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Carts")]
    public virtual User User { get; set; } = null!;
}
