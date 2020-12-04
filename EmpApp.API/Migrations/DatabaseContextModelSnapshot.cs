﻿// <auto-generated />
using System;
using CyberAge.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CyberAge.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EmpApp.Entities.Robot", b =>
                {
                    b.Property<Guid>("RobotGuid");

                    b.Property<int>("Energy");

                    b.Property<int>("Health");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Number");

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.HasKey("RobotGuid");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("EmpApp.Entities.User", b =>
                {
                    b.Property<Guid>("UserGuid");

                    b.Property<string>("Email");

                    b.Property<string>("Login")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.HasKey("UserGuid");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
