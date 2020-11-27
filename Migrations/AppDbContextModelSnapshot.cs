﻿// <auto-generated />
using System;
using MenuAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuAssignment.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MenuAssignment.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int?>("Reservationid");

                    b.HasKey("Id");

                    b.HasIndex("Reservationid");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("MenuAssignment.Models.OrderReservation", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("customerId");

                    b.HasKey("orderId");

                    b.HasIndex("customerId");

                    b.ToTable("OrderReservation");
                });

            modelBuilder.Entity("MenuAssignment.Models.Reservation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<int>("customerId");

                    b.HasKey("id");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("MenuAssignment.Models.MenuItem", b =>
                {
                    b.HasOne("MenuAssignment.Models.Reservation")
                        .WithMany("MenuItems")
                        .HasForeignKey("Reservationid");
                });

            modelBuilder.Entity("MenuAssignment.Models.OrderReservation", b =>
                {
                    b.HasOne("MenuAssignment.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("customerId");
                });
#pragma warning restore 612, 618
        }
    }
}
