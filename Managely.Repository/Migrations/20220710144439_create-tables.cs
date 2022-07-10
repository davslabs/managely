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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { new Guid("104e3817-f5db-4827-8874-70ccebe8ef45"), "Recursos Humanos", "HumanResources" },
                    { new Guid("2038d67f-3cb7-4a07-add8-e69c9dea629c"), "Comité de Gobernación", "Board" },
                    { new Guid("314b9b19-763e-4065-888f-aa5ba38b3f7a"), "Finanzas", "Finance" },
                    { new Guid("7634e360-6477-4775-9990-7de1cff73cc1"), "Ventas", "Sales" },
                    { new Guid("c3f9f08c-bca7-4f15-ab75-686ebfd39b37"), "Marketing", "Marketing" },
                    { new Guid("cbba8167-0f34-4de3-86c9-687d7ecbcddf"), "Servicio al Cliente", "CustomerService" },
                    { new Guid("e222d8fc-69b6-47da-a94e-9d6c6b017278"), "IT", "IT" }
                });

            migrationBuilder.InsertData(
                table: "JobPositions",
                columns: new[] { "JobPositionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("5cc7f86c-2490-4a77-8dc2-cca090c5c917"), "Gerente", "Manager" },
                    { new Guid("81655a6c-f0a6-4f85-8a9e-2cbf65f58ac5"), "Staff", "Staff" },
                    { new Guid("8ae3a1f7-e20b-4321-af64-5f1ffc7673c8"), "Lider", "Head" },
                    { new Guid("934fe9d3-13c5-4c99-8c67-92c518faf9de"), "CEO", "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0bf24c64-faff-4c70-a5f6-b39ad14d1893"), "Eliminar", "Delete" },
                    { new Guid("2c4c534f-7413-4f74-a716-becd91bdea86"), "Editar", "Update" },
                    { new Guid("37536f0d-2cfd-4c7c-9f0f-ec4e118ed7e5"), "Crear", "Create" },
                    { new Guid("cfaae55f-0424-4ba9-887b-9defed6c9835"), "Leer", "Read" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("03c74fb1-c1e8-4908-9d1c-d102e688e713"), "Admin", "Admin", true },
                    { new Guid("71277fc9-eed2-4296-8526-452376d76b21"), "Manager", "Manager", true },
                    { new Guid("c7730fd5-0520-4eb3-8857-ba673e55f3b2"), "Staff", "Staff", true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("32e34e30-4736-4c6a-8127-d72a0131429c"), new Guid("37536f0d-2cfd-4c7c-9f0f-ec4e118ed7e5"), new Guid("71277fc9-eed2-4296-8526-452376d76b21") },
                    { new Guid("42e5e386-9b0d-4525-af81-91308abc7f3f"), new Guid("cfaae55f-0424-4ba9-887b-9defed6c9835"), new Guid("71277fc9-eed2-4296-8526-452376d76b21") },
                    { new Guid("5e18e688-9e7e-4907-898f-9b005547e499"), new Guid("cfaae55f-0424-4ba9-887b-9defed6c9835"), new Guid("03c74fb1-c1e8-4908-9d1c-d102e688e713") },
                    { new Guid("62f770a8-3e8c-4699-aab0-07188b7fb98e"), new Guid("cfaae55f-0424-4ba9-887b-9defed6c9835"), new Guid("c7730fd5-0520-4eb3-8857-ba673e55f3b2") },
                    { new Guid("74d0d4b4-28f3-4586-8a24-9292e1289546"), new Guid("37536f0d-2cfd-4c7c-9f0f-ec4e118ed7e5"), new Guid("03c74fb1-c1e8-4908-9d1c-d102e688e713") },
                    { new Guid("806202b5-1878-482c-bcd1-dc85e727999a"), new Guid("2c4c534f-7413-4f74-a716-becd91bdea86"), new Guid("71277fc9-eed2-4296-8526-452376d76b21") },
                    { new Guid("c3a7cea6-5331-4819-ba05-621f69d3e805"), new Guid("0bf24c64-faff-4c70-a5f6-b39ad14d1893"), new Guid("03c74fb1-c1e8-4908-9d1c-d102e688e713") },
                    { new Guid("c3e41618-bc75-4135-ab5f-35e25afde882"), new Guid("2c4c534f-7413-4f74-a716-becd91bdea86"), new Guid("03c74fb1-c1e8-4908-9d1c-d102e688e713") },
                    { new Guid("ee36c83c-046f-484f-be1e-f44df5473c25"), new Guid("0bf24c64-faff-4c70-a5f6-b39ad14d1893"), new Guid("71277fc9-eed2-4296-8526-452376d76b21") }
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
