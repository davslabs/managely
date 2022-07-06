using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managely.Repository.Migrations
{
    public partial class createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    JobPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.JobPositionId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TimeOffs",
                columns: table => new
                {
                    TimeOffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThruDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOffs", x => x.TimeOffId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportsToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsToId",
                        column: x => x.ReportsToId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "JobPositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RolePermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimeOffs",
                columns: table => new
                {
                    EmployeTimeOffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeOffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeOffs", x => x.EmployeTimeOffId);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeOffs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeOffs_TimeOffs_TimeOffId",
                        column: x => x.TimeOffId,
                        principalTable: "TimeOffs",
                        principalColumn: "TimeOffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("45970721-aaf4-4cb5-9228-1ab98d05fb99"), "Finanzas", "Finance" },
                    { new Guid("47543b5d-777b-401c-aacd-03f6ca3338bb"), "Servicio al Cliente", "CustomerService" },
                    { new Guid("60ac2157-5ac3-40e6-83f7-3e73c7535be2"), "IT", "IT" },
                    { new Guid("a946c0c3-e6f8-485c-b0b9-e467b91a4d50"), "Comité de Gobernación", "Board" },
                    { new Guid("bc77e517-5ea8-4ab4-90ad-5141c77394bc"), "Recursos Humanos", "HumanResources" },
                    { new Guid("eb7e6209-04ad-402c-94c6-23e30134c474"), "Marketing", "Marketing" },
                    { new Guid("f7175037-d8dc-4154-9f39-87996f3ccb23"), "Ventas", "Sales" }
                });

            migrationBuilder.InsertData(
                table: "JobPositions",
                columns: new[] { "JobPositionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("09c7e8bb-7990-4a79-8b6e-9366f8846db1"), "CEO", "CEO" },
                    { new Guid("175d75b0-61c6-473a-8450-6beba67ddb83"), "Staff", "Staff" },
                    { new Guid("52dc736a-4b59-4184-90b7-336a8c1e15e0"), "Lider", "Head" },
                    { new Guid("ac98ae86-e49b-434f-ba99-cc6e43f9664f"), "Gerente", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"), "Eliminar", "Delete" },
                    { new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"), "Editar", "Update" },
                    { new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"), "Leer", "Read" },
                    { new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"), "Crear", "Create" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("1506515e-68db-4632-9160-21b00b0174c4"), "Staff", "Staff", true },
                    { new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7"), "Manager", "Manager", true },
                    { new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb"), "Admin", "Admin", true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0973d870-5b34-4de6-b977-bd508ad8637a"), new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"), new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb") },
                    { new Guid("1a101dfc-0f96-4b38-b969-11248ef2443b"), new Guid("20e32d8f-ffc4-4fa6-b07b-202cbce6f391"), new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7") },
                    { new Guid("20165046-c5e9-402c-a18e-de2261aedc92"), new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"), new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb") },
                    { new Guid("2f1b53a4-75b1-4ff7-bab1-ee5d1fe8dc79"), new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"), new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7") },
                    { new Guid("65a77d02-ed15-4958-8a1b-d60c8a2caa7e"), new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"), new Guid("1506515e-68db-4632-9160-21b00b0174c4") },
                    { new Guid("68a02498-3f88-4ad6-b90f-50119038b865"), new Guid("90eb2af9-1d20-484d-aa69-3967ac58cd5d"), new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7") },
                    { new Guid("6b1d10ed-4534-4110-baf1-fdc388809d68"), new Guid("def28ef2-1192-4b6d-abea-b66dfb3a2547"), new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb") },
                    { new Guid("6d1a4f96-5b03-4753-ab8e-cc5e0bc28b9c"), new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"), new Guid("1b463ded-62fa-42ae-90d9-e43bb06ff1e7") },
                    { new Guid("e5e321fa-2ae7-4d22-ad59-b1247b382b55"), new Guid("55ddf8f1-5f07-4646-93ad-fbb1cb474d83"), new Guid("58cc6503-8e2e-4cdf-8ad9-534127e4c3bb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionId",
                table: "Employees",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToId",
                table: "Employees",
                column: "ReportsToId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeOffs_EmployeeId",
                table: "EmployeeTimeOffs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeOffs_TimeOffId",
                table: "EmployeeTimeOffs",
                column: "TimeOffId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimeOffs");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TimeOffs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
