﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketsSystem.DAL;

#nullable disable

namespace TicketsSystem.DAL.Migrations
{
    [DbContext(typeof(TicketsSystemContext))]
    [Migration("20230403201929_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeveloperTicket", b =>
                {
                    b.Property<int>("DevelopersId")
                        .HasColumnType("int");

                    b.Property<int>("TicketsId")
                        .HasColumnType("int");

                    b.HasKey("DevelopersId", "TicketsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("DeveloperTicket");
                });

            modelBuilder.Entity("TicketsSystem.DAL.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Automotive & Baby"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beauty & Health"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronics"
                        });
                });

            modelBuilder.Entity("TicketsSystem.DAL.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Freddie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sophia"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Angela"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jamie"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Geoffrey"
                        });
                });

            modelBuilder.Entity("TicketsSystem.DAL.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EstimationCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Severity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 20,
                            DepartmentId = 1,
                            Description = "Harum hic impedit dolore voluptate placeat.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 1,
                            DepartmentId = 2,
                            Description = "Rerum totam est quo possimus sunt sunt ad.",
                            EstimationCost = 400m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 3,
                            Description = "Id cumque explicabo beatae.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            Description = "Consectetur beatae dolorem voluptates occaecati.",
                            EstimationCost = 300m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 3,
                            Description = "Nulla est doloribus ut non aspernatur vero dolores.",
                            EstimationCost = 200m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 2,
                            Description = "Et praesentium est ipsum eligendi rerum itaque voluptate quia.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 3,
                            Description = "Optio non debitis ut molestiae dolorem ad.",
                            EstimationCost = 100m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 1,
                            Description = "Dolor quae iure quas error est.",
                            EstimationCost = 200m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 2,
                            Description = "Iste molestiae aut inventore necessitatibus necessitatibus perspiciatis sit.",
                            EstimationCost = 200m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 2,
                            Description = "Voluptas expedita placeat ad sint consequuntur.",
                            EstimationCost = 200m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 10,
                            DepartmentId = 1,
                            Description = "Voluptates qui sed aliquid laudantium in.",
                            EstimationCost = 200m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 11,
                            DepartmentId = 3,
                            Description = "Placeat non repellat qui libero.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 12,
                            DepartmentId = 3,
                            Description = "Debitis vero laborum asperiores deserunt nihil tempora quia.",
                            EstimationCost = 200m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 13,
                            DepartmentId = 1,
                            Description = "Voluptatibus a et natus ipsa at quis rem dolores.",
                            EstimationCost = 500m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 14,
                            DepartmentId = 1,
                            Description = "Dolorem qui animi sint ad facere ut ullam voluptatem repellendus.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 15,
                            DepartmentId = 2,
                            Description = "Sint suscipit delectus accusamus distinctio earum aliquam.",
                            EstimationCost = 200m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 16,
                            DepartmentId = 2,
                            Description = "Et vel tempora.",
                            EstimationCost = 200m,
                            Severity = 0
                        },
                        new
                        {
                            Id = 17,
                            DepartmentId = 2,
                            Description = "Aut atque officiis numquam mollitia voluptas dolore.",
                            EstimationCost = 200m,
                            Severity = 1
                        },
                        new
                        {
                            Id = 18,
                            DepartmentId = 3,
                            Description = "Ipsum mollitia sit officiis sapiente natus.",
                            EstimationCost = 300m,
                            Severity = 2
                        },
                        new
                        {
                            Id = 19,
                            DepartmentId = 1,
                            Description = "Inventore aut reprehenderit vitae ratione dolorum harum.",
                            EstimationCost = 400m,
                            Severity = 2
                        });
                });

            modelBuilder.Entity("DeveloperTicket", b =>
                {
                    b.HasOne("TicketsSystem.DAL.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsSystem.DAL.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketsSystem.DAL.Ticket", b =>
                {
                    b.HasOne("TicketsSystem.DAL.Department", "Department")
                        .WithMany("Tickets")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TicketsSystem.DAL.Department", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
