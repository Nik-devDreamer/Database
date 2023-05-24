﻿// <auto-generated />
using System;
using Lab6.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab6.Migrations
{
    [DbContext(typeof(Internet_SalesContext))]
    [Migration("20230524202628_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab6.DBContext.Delivery", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("date")
                        .HasColumnName("date_order");

                    b.Property<string>("AddressDelivery")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address_delivery");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("DateDelivery")
                        .HasColumnType("date")
                        .HasColumnName("date_delivery");

                    b.HasKey("ProductId", "StoreId", "DateOrder")
                        .HasName("PK__Delivery__1E16CBB25E67CDFE");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("Lab6.DBContext.OnlineStore", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<string>("AddressStore")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address_store");

                    b.Property<string>("NameStore")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name_store");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telephone");

                    b.HasKey("StoreId")
                        .HasName("PK__Online_S__A2F2A30CF6EDDD92");

                    b.ToTable("Online_Store");
                });

            modelBuilder.Entity("Lab6.DBContext.Order", b =>
                {
                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("date")
                        .HasColumnName("date_order");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.HasKey("DateOrder", "ProductId", "StoreId")
                        .HasName("PK__Order__724EA2FE22ACF88A");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Lab6.DBContext.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("manufacturer");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name_product");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Lab6.DBContext.ProductOnlineStore", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.HasKey("ProductId", "StoreId")
                        .HasName("PK__Product___9D2D57C5AB3C3C2D");

                    b.HasIndex("StoreId");

                    b.ToTable("Product_Online_Store");
                });

            modelBuilder.Entity("Lab6.DBContext.Delivery", b =>
                {
                    b.HasOne("Lab6.DBContext.ProductOnlineStore", "ProductOnlineStore")
                        .WithMany("Deliveries")
                        .HasForeignKey("ProductId", "StoreId")
                        .HasConstraintName("fk_delivery_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOnlineStore");
                });

            modelBuilder.Entity("Lab6.DBContext.Order", b =>
                {
                    b.HasOne("Lab6.DBContext.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_order_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.DBContext.OnlineStore", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("fk_order_store")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Lab6.DBContext.ProductOnlineStore", b =>
                {
                    b.HasOne("Lab6.DBContext.Product", "Product")
                        .WithMany("ProductOnlineStores")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.DBContext.OnlineStore", "Store")
                        .WithMany("ProductOnlineStores")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("fk_store")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Lab6.DBContext.OnlineStore", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductOnlineStores");
                });

            modelBuilder.Entity("Lab6.DBContext.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductOnlineStores");
                });

            modelBuilder.Entity("Lab6.DBContext.ProductOnlineStore", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
