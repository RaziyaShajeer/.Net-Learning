using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models;

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

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }

    public virtual DbSet<RestaurantProfile> RestaurantProfiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RAZIYA;Initial Catalog=FoodOrdering;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_User");
        });

        modelBuilder.Entity<Cartitem>(entity =>
        {
            entity.Property(e => e.CartItemId).ValueGeneratedNever();

            entity.HasOne(d => d.Dish).WithMany(p => p.Cartitems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cartitem_Dish");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.Property(e => e.DishId).ValueGeneratedNever();

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Dishes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dish_RestaurantProfile");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LoactionId).ValueGeneratedNever();
            entity.Property(e => e.LocationName).IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.OrderItemId).ValueGeneratedNever();

            entity.HasOne(d => d.OrderItemNavigation).WithOne(p => p.OrderItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");
        });

        modelBuilder.Entity<RestaurantAdmin>(entity =>
        {
            entity.Property(e => e.RestaurantAdminId).ValueGeneratedNever();

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantAdmins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RestaurantAdmin_RestaurantProfile");
        });

        modelBuilder.Entity<RestaurantProfile>(entity =>
        {
            entity.Property(e => e.RestaurantId).ValueGeneratedNever();
            entity.Property(e => e.Phone).IsFixedLength();

            entity.HasOne(d => d.Location).WithMany(p => p.RestaurantProfiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RestaurantProfile_Location");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();

            entity.HasOne(d => d.Location).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
