using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lab6.DBContext
{
    public partial class Internet_SalesContext : DbContext
    {
        public Internet_SalesContext()
        {
        }

        public Internet_SalesContext(DbContextOptions<Internet_SalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<OnlineStore> OnlineStores { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOnlineStore> ProductOnlineStores { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NO2QI0R\\SQLEXPRESS;Initial Catalog=Internet_Sales;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StoreId, e.DateOrder })
                    .HasName("PK__Delivery__1E16CBB25E67CDFE");

                entity.ToTable("Delivery");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("date_order");

                entity.Property(e => e.AddressDelivery)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address_delivery");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.DateDelivery)
                    .HasColumnType("date")
                    .HasColumnName("date_delivery");

                entity.HasOne(d => d.ProductOnlineStore)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => new { d.ProductId, d.StoreId })
                    .HasConstraintName("fk_delivery_product");
            });

            modelBuilder.Entity<OnlineStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Online_S__A2F2A30CF6EDDD92");

                entity.ToTable("Online_Store");

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("store_id");

                entity.Property(e => e.AddressStore)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address_store");

                entity.Property(e => e.NameStore)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_store");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.DateOrder, e.ProductId, e.StoreId })
                    .HasName("PK__Order__724EA2FE22ACF88A");

                entity.ToTable("Order");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("date_order");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_order_product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("fk_order_store");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.NameProduct)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_product");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<ProductOnlineStore>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StoreId })
                    .HasName("PK__Product___9D2D57C5AB3C3C2D");

                entity.ToTable("Product_Online_Store");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOnlineStores)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductOnlineStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("fk_store");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ReviewId })
                    .HasName("PK__Review__510AFE2CD58B217A");

                entity.ToTable("Review");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_review_product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
