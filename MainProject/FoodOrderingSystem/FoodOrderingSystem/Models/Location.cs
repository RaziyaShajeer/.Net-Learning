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
    public Guid LocationId { get; set; }= Guid.NewGuid();

    [StringLength(10)]
    [Unicode(false)]
    public string LocationName { get; set; } = null!;

    
    
}
