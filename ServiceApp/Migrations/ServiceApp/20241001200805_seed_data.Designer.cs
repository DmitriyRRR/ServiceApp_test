﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceApp.Database;

#nullable disable

namespace ServiceApp.Migrations.ServiceApp
{
    [DbContext(typeof(ServiceAppContext))]
    [Migration("20241001200805_seed_data")]
    partial class seed_data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServiceApp.Database.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jhon"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Den"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tom"
                        });
                });

            modelBuilder.Entity("ServiceApp.Database.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Cell phone with 5G",
                            Name = "Iphone"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Laptop Lenovo",
                            Name = "ThinkBook 15"
                        },
                        new
                        {
                            Id = 3,
                            Description = "SSD",
                            Name = "Samung 870 EVO"
                        });
                });

            modelBuilder.Entity("ServiceApp.Database.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
