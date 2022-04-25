using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreWebApplication
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerÀdress> CustomerÀdresses { get; set; } = null!;
        public virtual DbSet<Firm> Firms { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= MARTARAK8C3C\\SQLEXPRESS; Database=OnlineShop; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoriesId);

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<CustomerÀdress>(entity =>
            {
                entity.HasKey(e => e.CustomerAdressId);

                entity.Property(e => e.CustomerAdressId).HasColumnName("CustomerAdressID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerÀdresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerÀdresses_Customers");
            });

            modelBuilder.Entity<Firm>(entity =>
            {
                entity.Property(e => e.FirmId).HasColumnName("FirmID");

                entity.Property(e => e.Capital).HasColumnType("money");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Owner).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerAdressId).HasColumnName("CustomerAdressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(e => e.OrderProductId).HasColumnName("OrderProductID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts_Products");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderStatus1)
                    .HasMaxLength(20)
                    .HasColumnName("OrderStatus");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderStatuses)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderStatuses_Orders");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.FirmId).HasColumnName("FirmID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Firms");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.ProductImageId).HasColumnName("ProductImageID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImages_Products");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
