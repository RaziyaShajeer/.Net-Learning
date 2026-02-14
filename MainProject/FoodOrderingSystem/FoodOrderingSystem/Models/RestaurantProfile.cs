using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrderingSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("RestaurantProfile")]
public partial class RestaurantProfile
{
    [Key]
    public Guid RestaurantId { get; set; }=Guid.NewGuid();  

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Name is required.")]

    public string RestaurantName { get; set; } = null!;
    [Required(ErrorMessage = "Type is required.")]

    public RestaurantType RestauratType { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }

	[StringLength(10)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    public string LocationName { get; set; }

    public string Restaurantimage { get; set; }
    public RestaurantStatus Status {get; set; }



    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [InverseProperty("Restaurant")]
    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();


   

    [InverseProperty("Restaurant")]
    public virtual ICollection<RestaurantAdmin> RestaurantAdmins { get; set; } = new List<RestaurantAdmin>();
}
