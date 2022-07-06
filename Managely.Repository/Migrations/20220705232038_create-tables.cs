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
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false)
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
                    isEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_Employees_Employees_ReportsToId",
                        column: x => x.ReportsToId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Name" },
                values: new object[,]
                {
                    { new Guid("17cb5565-4f1b-47c3-b259-5c2d58e2d9dc"), "Create" },
                    { new Guid("68350ed0-20a1-4dc6-bdfc-ee21d07fc6f0"), "Delete" },
                    { new Guid("720d056c-2b0b-491c-9b42-a72deaaf5b69"), "Update" },
                    { new Guid("7421b89c-7f2e-4fee-b37e-d9e5dd8b71ad"), "Read" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("242f13f4-8378-4f4a-a859-811db5ba2441"), "Staff", false },
                    { new Guid("5fbdce58-4c20-4c55-a73b-cedac8dcdfd6"), "Admin", false },
                    { new Guid("6f57fd31-e970-4cd3-aa83-466a800a017b"), "Manager", false }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("5ddabcda-ef4b-4d09-ac10-a557fa897b67"), new Guid("7421b89c-7f2e-4fee-b37e-d9e5dd8b71ad"), new Guid("5fbdce58-4c20-4c55-a73b-cedac8dcdfd6") },
                    { new Guid("6c0e46e8-1f74-4067-8ae1-4c7cd0eafc45"), new Guid("7421b89c-7f2e-4fee-b37e-d9e5dd8b71ad"), new Guid("6f57fd31-e970-4cd3-aa83-466a800a017b") },
                    { new Guid("7a1e5d00-32d7-42f6-a5f4-9be114287f91"), new Guid("720d056c-2b0b-491c-9b42-a72deaaf5b69"), new Guid("6f57fd31-e970-4cd3-aa83-466a800a017b") },
                    { new Guid("7a668c66-3138-4553-b9ad-562f5bd6e98a"), new Guid("7421b89c-7f2e-4fee-b37e-d9e5dd8b71ad"), new Guid("242f13f4-8378-4f4a-a859-811db5ba2441") },
                    { new Guid("ae5647b9-3a91-4235-9a5e-8e8b9af9c3ac"), new Guid("17cb5565-4f1b-47c3-b259-5c2d58e2d9dc"), new Guid("6f57fd31-e970-4cd3-aa83-466a800a017b") },
                    { new Guid("bff3bec4-2093-40e0-8518-c0a15ea7c97a"), new Guid("68350ed0-20a1-4dc6-bdfc-ee21d07fc6f0"), new Guid("5fbdce58-4c20-4c55-a73b-cedac8dcdfd6") },
                    { new Guid("c7610f5b-e29a-4c5b-bdb1-c82e4dc3aa25"), new Guid("17cb5565-4f1b-47c3-b259-5c2d58e2d9dc"), new Guid("5fbdce58-4c20-4c55-a73b-cedac8dcdfd6") },
                    { new Guid("f09ebc3a-5fc2-4ed2-832e-02f31c9431ef"), new Guid("720d056c-2b0b-491c-9b42-a72deaaf5b69"), new Guid("5fbdce58-4c20-4c55-a73b-cedac8dcdfd6") },
                    { new Guid("f0f1cae7-9c5d-4257-8a17-e549764e9360"), new Guid("68350ed0-20a1-4dc6-bdfc-ee21d07fc6f0"), new Guid("6f57fd31-e970-4cd3-aa83-466a800a017b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToId",
                table: "Employees",
                column: "ReportsToId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
