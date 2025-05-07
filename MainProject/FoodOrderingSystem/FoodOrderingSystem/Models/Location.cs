using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("Location")]
public partial class Location
{
    [Key]
    public Guid LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LocationName { get; set; } = null!;

    [InverseProperty("Location")]
    public virtual ICollection<MyUser> MyUsers { get; set; } = new List<MyUser>();

    [InverseProperty("Location")]
    public virtual ICollection<RestaurantProfile> RestaurantProfiles { get; set; } = new List<RestaurantProfile>();
}
