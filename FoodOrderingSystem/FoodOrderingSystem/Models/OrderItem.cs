using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("OrderItem")]
public partial class OrderItem
{
    [Key]
    public Guid OrderItemId { get; set; }

    [Column("orderId")]
    public Guid OrderId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("OrderItemId")]
    [InverseProperty("OrderItem")]
    public virtual MyOrder OrderItemNavigation { get; set; } = null!;
}
