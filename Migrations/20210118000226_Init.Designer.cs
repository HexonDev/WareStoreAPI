﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WareStoreAPI.Data;

namespace WareStoreAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210118000226_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WareStoreAPI.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AddressString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WareStoreAPI.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("StorageId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StoreId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WareStoreAPI.Models.ProductData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductData");
                });

            modelBuilder.Entity("WareStoreAPI.Models.Storage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("WareStoreAPI.Models.Store", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("StorageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("StorageId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("WareStoreAPI.Models.Product", b =>
                {
                    b.HasOne("WareStoreAPI.Models.Storage", null)
                        .WithMany("Products")
                        .HasForeignKey("StorageId");

                    b.HasOne("WareStoreAPI.Models.Store", null)
                        .WithMany("Stock")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("WareStoreAPI.Models.ProductData", b =>
                {
                    b.HasOne("WareStoreAPI.Models.Product", null)
                        .WithMany("Data")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("WareStoreAPI.Models.Storage", b =>
                {
                    b.HasOne("WareStoreAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WareStoreAPI.Models.Store", b =>
                {
                    b.HasOne("WareStoreAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareStoreAPI.Models.Storage", null)
                        .WithMany("Stores")
                        .HasForeignKey("StorageId");
                });
#pragma warning restore 612, 618
        }
    }
}