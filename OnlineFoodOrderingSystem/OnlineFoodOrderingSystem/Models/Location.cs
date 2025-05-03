using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("Location")]
public partial class Location
{
    [Key]
    public Guid LoactionId { get; set; }

    [StringLength(10)]
    public string LocationName { get; set; } = null!;

    [InverseProperty("Location")]
    public virtual ICollection<RestaurantProfile> RestaurantProfiles { get; set; } = new List<RestaurantProfile>();

    [InverseProperty("Location")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Abc> abcs { get; set; }
}
