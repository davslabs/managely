﻿// <auto-generated />
using System;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Managely.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Managely.Domain.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = new Guid("60ac2157-5ac3-40e6-83f7-3e73c7535be2"),
                            Description = "IT",
                            Name = "IT"
                        },
                        new
                        {
                            DepartmentId = new Guid("45970721-aaf4-4cb5-9228-1ab98d05fb99"),
                            Description = "Finanzas",
                            Name = "Finance"
                        },
                        new
                        {
                            DepartmentId = new Guid("eb7e6209-04ad-402c-94c6-23e30134c474"),
                            Description = "Marketing",
                            Name = "Marketing"
                        },
                        new
                        {
                            DepartmentId = new Guid("f7175037-d8dc-4154-9f39-87996f3ccb23"),
                            Description = "Ventas",
                            Name = "Sales"
                        },
                        new
                        {
                            DepartmentId = new Guid("bc77e517-5ea8-4ab4-90ad-5141c77394bc"),
                            Description = "Recursos Humanos",
                            Name = "HumanResources"
                        },
                        new
                        {
                            DepartmentId = new Guid("47543b5d-777b-401c-aacd-03f6ca3338bb"),
                            Description = "Servicio al Cliente",
                            Name = "CustomerService"
                        },
                        new
                        {
                            DepartmentId = new Guid("a946c0c3-e6f8-485c-b0b9-e467b91a4d50"),
                            Description = "Comité de Gobernación",
                            Name = "Board"
                        });
                });

            modelBuilder.Entity("Managely.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("JobPositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReportsToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobPositionId");

                    b.HasIndex("ReportsToId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Managely.Domain.Models.EmployeeTimeOff", b =>
                {
                    b.Property<Guid>("EmployeTimeOffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeOffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeTimeOffId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TimeOffId");

                    b.ToTable("EmployeeTimeOffs");
                });

            modelBuilder.Entity("Managely.Domain.Models.JobPosition", b =>
                {
                    b.Property<Guid>("JobPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("JobPositionId");

                    b.ToTable("JobPositions");

                    b.HasData(
                        new
                        {
                            JobPositionId = new Guid("52dc736a-4b59-4184-90b7-336a8c1e15e0"),
                            Description = "Lider",
                            Name = "Head"
                        },
                        new
                        {
                            JobPositionId = new Guid("ac98ae86-e49b-434f-ba99-cc6e43f9664f"),
                            Description = "Gerente",
                            Name = "Manager"
                        },
                        new
                        {
                            JobPositionId = new Guid("175d75b0-61c6-473a-8450-6beba67ddb83"),
                            Description = "Staff",
                            Name = "Staff"
                        },
                        new
                        {
                            JobPositionId = new Guid("09c7e8bb-7990-4a79-8b6e-9366f8846db1"),
                            Description = "CEO",
                            Name = "CEO"
                        });
                });

            modelBuilder.Entity("Managely.Domain.Models.Permission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            PermissionId = new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"),
                            Description = "Crear",
                            Name = "Create"
                        },
                        new
                        {
                            PermissionId = new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"),
                            Description = "Editar",
                            Name = "Update"
                        },
                        new
                        {
                            PermissionId = new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"),
                            Description = "Leer",
                            Name = "Read"
                        },
                        new
                        {
                            PermissionId = new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"),
                            Description = "Eliminar",
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("Managely.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb"),
                            Description = "Admin",
                            Name = "Admin",
                            isEnabled = true
                        },
                        new
                        {
                            RoleId = new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7"),
                            Description = "Manager",
                            Name = "Manager",
                            isEnabled = true
                        },
                        new
                        {
                            RoleId = new Guid("1506515e-68db-4632-9160-21b00b0174c4"),
                            Description = "Staff",
                            Name = "Staff",
                            isEnabled = true
                        });
                });

            modelBuilder.Entity("Managely.Domain.Models.RolePermission", b =>
                {
                    b.Property<Guid>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RolePermissionId = new Guid("6b1d10ed-4534-4110-baf1-fdc388809d68"),
                            PermissionId = new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"),
                            RoleId = new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb")
                        },
                        new
                        {
                            RolePermissionId = new Guid("2f1b53a4-75b1-4ff7-bab1-ee5d1fe8dc79"),
                            PermissionId = new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"),
                            RoleId = new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7")
                        },
                        new
                        {
                            RolePermissionId = new Guid("e5e321fa-2ae7-4d22-ad59-b1247b382b55"),
                            PermissionId = new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"),
                            RoleId = new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb")
                        },
                        new
                        {
                            RolePermissionId = new Guid("6d1a4f96-5b03-4753-ab8e-cc5e0bc28b9c"),
                            PermissionId = new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"),
                            RoleId = new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7")
                        },
                        new
                        {
                            RolePermissionId = new Guid("20165046-c5e9-402c-a18e-de2261aedc92"),
                            PermissionId = new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"),
                            RoleId = new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb")
                        },
                        new
                        {
                            RolePermissionId = new Guid("68a02498-3f88-4ad6-b90f-50119038b865"),
                            PermissionId = new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"),
                            RoleId = new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7")
                        },
                        new
                        {
                            RolePermissionId = new Guid("0973d870-5b34-4de6-b977-bd508ad8637a"),
                            PermissionId = new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"),
                            RoleId = new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb")
                        },
                        new
                        {
                            RolePermissionId = new Guid("1a101dfc-0f96-4b38-b969-11248ef2443b"),
                            PermissionId = new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"),
                            RoleId = new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7")
                        },
                        new
                        {
                            RolePermissionId = new Guid("65a77d02-ed15-4958-8a1b-d60c8a2caa7e"),
                            PermissionId = new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"),
                            RoleId = new Guid("1506515e-68db-4632-9160-21b00b0174c4")
                        });
                });

            modelBuilder.Entity("Managely.Domain.Models.TimeOff", b =>
                {
                    b.Property<Guid>("TimeOffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<DateTime>("ThruDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeOffId");

                    b.ToTable("TimeOffs");
                });

            modelBuilder.Entity("Managely.Domain.Models.Employee", b =>
                {
                    b.HasOne("Managely.Domain.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managely.Domain.Models.JobPosition", "JobPosition")
                        .WithMany("Employees")
                        .HasForeignKey("JobPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managely.Domain.Models.Employee", "ReportsTo")
                        .WithMany()
                        .HasForeignKey("ReportsToId");

                    b.HasOne("Managely.Domain.Models.Role", "Role")
                        .WithMany("Employee")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("JobPosition");

                    b.Navigation("ReportsTo");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Managely.Domain.Models.EmployeeTimeOff", b =>
                {
                    b.HasOne("Managely.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeTimeOffs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managely.Domain.Models.TimeOff", "TimeOff")
                        .WithMany("EmployeeTimeOffs")
                        .HasForeignKey("TimeOffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TimeOff");
                });

            modelBuilder.Entity("Managely.Domain.Models.RolePermission", b =>
                {
                    b.HasOne("Managely.Domain.Models.Permission", null)
                        .WithMany("RolePermission")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managely.Domain.Models.Role", null)
                        .WithMany("RolePermission")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Managely.Domain.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Managely.Domain.Models.Employee", b =>
                {
                    b.Navigation("EmployeeTimeOffs");
                });

            modelBuilder.Entity("Managely.Domain.Models.JobPosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Managely.Domain.Models.Permission", b =>
                {
                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Managely.Domain.Models.Role", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Managely.Domain.Models.TimeOff", b =>
                {
                    b.Navigation("EmployeeTimeOffs");
                });
#pragma warning restore 612, 618
        }
    }
}
