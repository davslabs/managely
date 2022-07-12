using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managely.Repository.Migrations
{
    public partial class CreateTables : Migration
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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("0fb22393-69e8-47be-8fd3-7a8306e43c96"), "Recursos Humanos", "HumanResources" },
                    { new Guid("186c9446-cb0b-4db9-a216-fb5ff6c40e4f"), "Marketing", "Marketing" },
                    { new Guid("41f73399-28d0-4538-ae7a-84bc7a63b283"), "Finanzas", "Finance" },
                    { new Guid("4290bfc8-c384-4170-8143-262f2e548577"), "IT", "IT" },
                    { new Guid("4a82fd01-2301-4115-8d26-74168675aadd"), "Servicio al Cliente", "CustomerService" },
                    { new Guid("7985a54b-9fe4-44eb-b8ea-25f047d2c970"), "Comité de Gobernación", "Board" },
                    { new Guid("a35650f2-5146-4263-b042-5755db7d2954"), "Ventas", "Sales" }
                });

            migrationBuilder.InsertData(
                table: "JobPositions",
                columns: new[] { "JobPositionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1a524604-9312-4d77-af7a-82070da3a447"), "Gerente", "Manager" },
                    { new Guid("a307c0b9-d8d0-484f-8f44-c64a6530060a"), "Staff", "Staff" },
                    { new Guid("ae475304-61fd-4e64-a000-089419f05c43"), "CEO", "CEO" },
                    { new Guid("c789d06e-3e1d-4b54-a7c8-94c40532f8b3"), "Lider", "Head" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0a26a041-2921-468a-b68f-2f9175e2224c"), "Eliminar", "Delete" },
                    { new Guid("20c76f55-686f-40b2-a845-2cd0a95c41f4"), "Leer", "Read" },
                    { new Guid("b5ccdf0a-6887-4616-b2a1-6285a5a8c235"), "Editar", "Update" },
                    { new Guid("ca9b2b73-4235-42eb-9a3b-f1adc216b77b"), "Crear", "Create" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("8b8fdb6d-69ed-4bea-96d5-45147873cddb"), "Staff", "Staff", true },
                    { new Guid("ba6e0189-891c-4081-b6fa-53665e56c1ee"), "Admin", "Admin", true },
                    { new Guid("f2cd6c6d-7a4a-40df-97e8-62f1e42a2944"), "Manager", "Manager", true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("01770bbe-eff2-4042-85bb-b826a7ed1dfe"), new Guid("0a26a041-2921-468a-b68f-2f9175e2224c"), new Guid("ba6e0189-891c-4081-b6fa-53665e56c1ee") },
                    { new Guid("0c0be631-f3e5-4390-8e9d-4428f35aaf89"), new Guid("20c76f55-686f-40b2-a845-2cd0a95c41f4"), new Guid("ba6e0189-891c-4081-b6fa-53665e56c1ee") },
                    { new Guid("335f1cf0-c0fe-4710-b3cd-525912492a0a"), new Guid("20c76f55-686f-40b2-a845-2cd0a95c41f4"), new Guid("8b8fdb6d-69ed-4bea-96d5-45147873cddb") },
                    { new Guid("65197d0d-8cf3-43f4-8df3-a9c1602bee63"), new Guid("b5ccdf0a-6887-4616-b2a1-6285a5a8c235"), new Guid("ba6e0189-891c-4081-b6fa-53665e56c1ee") },
                    { new Guid("84626364-32d9-45b6-8a56-cbaa4f72e47d"), new Guid("20c76f55-686f-40b2-a845-2cd0a95c41f4"), new Guid("f2cd6c6d-7a4a-40df-97e8-62f1e42a2944") },
                    { new Guid("a233ea90-00e2-4838-b90b-f3b1b8c22ce8"), new Guid("b5ccdf0a-6887-4616-b2a1-6285a5a8c235"), new Guid("f2cd6c6d-7a4a-40df-97e8-62f1e42a2944") },
                    { new Guid("e23b0d0a-946d-48ca-930c-38279c55e77e"), new Guid("0a26a041-2921-468a-b68f-2f9175e2224c"), new Guid("f2cd6c6d-7a4a-40df-97e8-62f1e42a2944") },
                    { new Guid("f65bad2e-87b0-4be1-acda-ba82b4c88a65"), new Guid("ca9b2b73-4235-42eb-9a3b-f1adc216b77b"), new Guid("f2cd6c6d-7a4a-40df-97e8-62f1e42a2944") },
                    { new Guid("fa171399-152c-46f6-83f1-ea7c09a65a9f"), new Guid("ca9b2b73-4235-42eb-9a3b-f1adc216b77b"), new Guid("ba6e0189-891c-4081-b6fa-53665e56c1ee") }
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
