using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("Order")]
public partial class Order
{
    [Key]
    public Guid OrderId { get; set; }

    public Guid UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("OrderItemNavigation")]
    public virtual OrderItem? OrderItem { get; set; }
}
