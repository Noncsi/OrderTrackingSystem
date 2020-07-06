﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderTrackingApp.Models;

namespace OrderTrackingApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20200703221520_AddOrderStatuses")]
    partial class AddOrderStatuses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderTrackingApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("OrderTrackingApp.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("StatusId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OrderTrackingApp.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("FullName");

                    b.Property<string>("HungarianTranslation");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("OrderTrackingApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("OrderTrackingApp.Models.Item", b =>
                {
                    b.HasOne("OrderTrackingApp.Models.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("OrderTrackingApp.Models.Order", b =>
                {
                    b.HasOne("OrderTrackingApp.Models.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("OrderTrackingApp.Models.User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
