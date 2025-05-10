 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrderingSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

[Table("MyUser")]
public partial class MyUser
{
    [Key]
    public Guid UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "FirstName is required.")]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "LastName is required.")]

    public string? Lastname { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Email required.")]

    public string Email { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    [Required(ErrorMessage = "Contactnumber is required.")]

    public string Phone { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    [Required(ErrorMessage = "Address is required.")]

    public string Address { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    [Required(ErrorMessage = "password is required.")]

    public string Password { get; set; } = null!;

    public Role Role { get; set; }

    public Guid? LocationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }= DateTime.Now;

    [InverseProperty("User")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("LocationId")]
    [InverseProperty("MyUsers")]
    public virtual Location Location { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<MyOrder> MyOrders { get; set; } = new List<MyOrder>();
}
