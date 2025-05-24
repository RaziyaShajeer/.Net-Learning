using System;
using System.Collections.Generic;
using FoodOrderingSystem.DTOs;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=FoodOrdering;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B78862E83E");

            entity.Property(e => e.CartId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_User");
        });

        modelBuilder.Entity<Cartitem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Cartitem__488B0B0A3FD7C69B");

            entity.Property(e => e.CartItemId).ValueGeneratedNever();

            entity.HasOne(d => d.Dish).WithMany(p => p.Cartitems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cartitem_Dish");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__Dish__18834F501F9461B5");

            entity.Property(e => e.DishId).ValueGeneratedNever();

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Dishes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dish_RestaurantProfile");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4975324939F");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MyOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__MyOrder__C3905BCFFB2199AF");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.MyOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<MyUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__MyUser__1788CC4C3F1B5C0A");

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.Location).WithMany(p => p.MyUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MyUser_Location");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06813226F653");

            entity.Property(e => e.OrderItemId).ValueGeneratedNever();

            entity.HasOne(d => d.OrderItemNavigation).WithOne(p => p.OrderItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");
        });

        modelBuilder.Entity<RestaurantAdmin>(entity =>
        {
            entity.HasKey(e => e.RestaurantAdminId).HasName("PK__Restaura__F5EA8F876F0D6D3A");

            entity.Property(e => e.RestaurantAdminId).ValueGeneratedNever();

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantAdmins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RestaurantAdmin_RestaurantProfile");
        });

        modelBuilder.Entity<UserDTo>().HasNoKey();

        modelBuilder.Entity<RestaurantProfile>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454C95236D507F");

            entity.Property(e => e.RestaurantId).ValueGeneratedNever();

            entity.HasOne(d => d.Location).WithMany(p => p.RestaurantProfiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RestaurantProfile_Location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<FoodOrderingSystem.DTOs.UserDTo> UserDTO { get; set; } = default!;
}
