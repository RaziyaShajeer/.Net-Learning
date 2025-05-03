using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("RestaurantAdmin")]
public partial class RestaurantAdmin
{
    [Key]
    public Guid RestaurantAdminId { get; set; }

    public Guid RestaurantId { get; set; }

    [ForeignKey("RestaurantId")]
    [InverseProperty("RestaurantAdmins")]
    public virtual RestaurantProfile Restaurant { get; set; } = null!;
}
