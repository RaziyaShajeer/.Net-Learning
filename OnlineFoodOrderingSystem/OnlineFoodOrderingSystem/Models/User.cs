using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

[Table("User")]
public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(10)]
    public string State { get; set; } = null!;

    [StringLength(10)]
    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public Guid LocationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("LocationId")]
    [InverseProperty("Users")]
    public virtual Location Location { get; set; } = null!;
}
