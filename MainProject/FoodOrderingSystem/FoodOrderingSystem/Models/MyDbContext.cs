using System;
using System.Collections.Generic;
using FoodOrderingSystem.DTO;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;

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
    public virtual DbSet<Logins> Logins { get; set; }   


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=Online_Food_Ordering;Integrated Security=True;Trust Server Certificate=True");

    
}
