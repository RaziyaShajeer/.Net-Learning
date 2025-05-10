using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("RestaurantProfile")]
public partial class RestaurantProfile
{
    [Key]
    public Guid RestaurantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Name is required.")]

    public string RestaurantName { get; set; } = null!;
    [Required(ErrorMessage = "Type is required.")]

    public int RestauratType { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    public Guid LocationId { get; set; }

    public byte[]? RestaurantImage { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Restaurant")]
    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    [ForeignKey("LocationId")]
    [InverseProperty("RestaurantProfiles")]
    public virtual Location Location { get; set; } = null!;

    [InverseProperty("Restaurant")]
    public virtual ICollection<RestaurantAdmin> RestaurantAdmins { get; set; } = new List<RestaurantAdmin>();
}
