﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrdersService;

#nullable disable

namespace OrdersService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230427151118_ChangedFKs")]
    partial class ChangedFKs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrdersService.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrdersService.Models.OrderLine", b =>
                {
                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("OrdersService.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7054e065-946f-4c07-b603-9a50103acaae"),
                            Name = "Notebook"
                        },
                        new
                        {
                            Id = new Guid("eccea7ae-ed79-4848-b205-c05b9cad362d"),
                            Name = "Computer"
                        },
                        new
                        {
                            Id = new Guid("946f34f1-af13-4557-9743-39d4beca44fb"),
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("OrdersService.Models.OrderLine", b =>
                {
                    b.HasOne("OrdersService.Models.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrdersService.Models.Product", "Product")
                        .WithMany("OrderLine")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrdersService.Models.Order", b =>
                {
                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("OrdersService.Models.Product", b =>
                {
                    b.Navigation("OrderLine");
                });
#pragma warning restore 612, 618
        }
    }
}
