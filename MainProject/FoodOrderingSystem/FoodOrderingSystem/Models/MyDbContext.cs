using System;
using System.Collections.Generic;
using FoodOrderingSystem.DTO;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Cartitem> Cartitems { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MyOrder> MyOrders { get; set; }

    public virtual DbSet<MyUser> MyUsers { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }

    public virtual DbSet<RestaurantProfile> RestaurantProfiles { get; set; }
    public virtual DbSet<Category> Category { get; set; }   

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=FoodOrdering1;Integrated Security=True;Trust Server Certificate=True");
	}

public DbSet<FoodOrderingSystem.DTO.CategoryDTO> CategoryDTO { get; set; } = default!;




}
