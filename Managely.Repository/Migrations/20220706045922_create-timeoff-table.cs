using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managely.Repository.Migrations
{
    public partial class createtimeofftable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("344e8fce-648b-42f2-ac32-b2467acb328a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("3c4446d6-c6f6-4b8f-9e28-626e0f413c14"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("4140734c-afc1-4dba-8059-0b5f7c89f89c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("6183d11b-170a-4ee7-b715-1afcdc37aceb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("7d8078bc-55bd-4b6c-8892-b93cffc1fadf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("b3d56158-1377-4846-ad8b-4b042be39e54"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("cf6c4c61-9740-4b01-8a4d-e5c3b261169a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("d4465959-2ce6-46e9-b1a8-ce1aa0236c19"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("dc7cb3d9-aa5b-47fa-840c-0fd82552e348"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("132240b8-3603-45a3-bf4b-ffdaaab402ad"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("2696e840-a6b2-4f30-9c9c-c1503863f534"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("769970f3-2b39-4721-a760-acdf92b1911a"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("8991476c-003a-4aec-bb11-ee834367f987"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b8e17611-767d-4b2a-a9dc-e8914572b153"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d719f312-1d6b-4b99-85b6-31f90e365775"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Name" },
                values: new object[,]
                {
                    { new Guid("07ab6738-56df-4c71-83b5-3f48ec1b9e64"), "Create" },
                    { new Guid("b728b46c-914c-456a-834d-5936e722b151"), "Update" },
                    { new Guid("bbc97065-0fb3-491e-89f8-cbe098a0a3d1"), "Read" },
                    { new Guid("bd6a7c6a-a36a-4063-8c2b-9713ea14b5c4"), "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb"), "Manager", false },
                    { new Guid("5eb8a414-048a-4dbf-9bb0-f68cb9609ace"), "Staff", false },
                    { new Guid("ececa461-89bf-46e4-9864-48001ba7c694"), "Admin", false }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("366bdb88-e82a-4d29-8ed3-1f31315c1259"), new Guid("bbc97065-0fb3-491e-89f8-cbe098a0a3d1"), new Guid("ececa461-89bf-46e4-9864-48001ba7c694") },
                    { new Guid("44dbb97a-6285-4ef1-ab92-5626abbe3e40"), new Guid("bd6a7c6a-a36a-4063-8c2b-9713ea14b5c4"), new Guid("ececa461-89bf-46e4-9864-48001ba7c694") },
                    { new Guid("54217dff-805f-4185-8098-30002bc72e6d"), new Guid("07ab6738-56df-4c71-83b5-3f48ec1b9e64"), new Guid("ececa461-89bf-46e4-9864-48001ba7c694") },
                    { new Guid("62d6ab1c-925f-438d-bc51-354a00f14d0e"), new Guid("b728b46c-914c-456a-834d-5936e722b151"), new Guid("ececa461-89bf-46e4-9864-48001ba7c694") },
                    { new Guid("8972d553-1edd-44f0-92b8-077605d6b03e"), new Guid("07ab6738-56df-4c71-83b5-3f48ec1b9e64"), new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb") },
                    { new Guid("b053af1d-5d25-44bb-a25f-65313514c909"), new Guid("bd6a7c6a-a36a-4063-8c2b-9713ea14b5c4"), new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb") },
                    { new Guid("d1167301-6072-4fed-9634-5d1826cc102b"), new Guid("bbc97065-0fb3-491e-89f8-cbe098a0a3d1"), new Guid("5eb8a414-048a-4dbf-9bb0-f68cb9609ace") },
                    { new Guid("f4d5cf36-7afa-40c9-b2c3-1132078ca2f1"), new Guid("b728b46c-914c-456a-834d-5936e722b151"), new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb") },
                    { new Guid("f85d1311-276d-43bc-8b63-abfe2e7481db"), new Guid("bbc97065-0fb3-491e-89f8-cbe098a0a3d1"), new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("366bdb88-e82a-4d29-8ed3-1f31315c1259"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("44dbb97a-6285-4ef1-ab92-5626abbe3e40"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("54217dff-805f-4185-8098-30002bc72e6d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("62d6ab1c-925f-438d-bc51-354a00f14d0e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("8972d553-1edd-44f0-92b8-077605d6b03e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("b053af1d-5d25-44bb-a25f-65313514c909"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("d1167301-6072-4fed-9634-5d1826cc102b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("f4d5cf36-7afa-40c9-b2c3-1132078ca2f1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RolePermissionId",
                keyValue: new Guid("f85d1311-276d-43bc-8b63-abfe2e7481db"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("07ab6738-56df-4c71-83b5-3f48ec1b9e64"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("b728b46c-914c-456a-834d-5936e722b151"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("bbc97065-0fb3-491e-89f8-cbe098a0a3d1"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: new Guid("bd6a7c6a-a36a-4063-8c2b-9713ea14b5c4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2a287f3f-7b50-4837-8b55-fbfd8e04e9fb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5eb8a414-048a-4dbf-9bb0-f68cb9609ace"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ececa461-89bf-46e4-9864-48001ba7c694"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Name" },
                values: new object[,]
                {
                    { new Guid("132240b8-3603-45a3-bf4b-ffdaaab402ad"), "Read" },
                    { new Guid("2696e840-a6b2-4f30-9c9c-c1503863f534"), "Create" },
                    { new Guid("769970f3-2b39-4721-a760-acdf92b1911a"), "Update" },
                    { new Guid("8991476c-003a-4aec-bb11-ee834367f987"), "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "isEnabled" },
                values: new object[,]
                {
                    { new Guid("b8e17611-767d-4b2a-a9dc-e8914572b153"), "Staff", false },
                    { new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5"), "Manager", false },
                    { new Guid("d719f312-1d6b-4b99-85b6-31f90e365775"), "Admin", false }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("344e8fce-648b-42f2-ac32-b2467acb328a"), new Guid("132240b8-3603-45a3-bf4b-ffdaaab402ad"), new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5") },
                    { new Guid("3c4446d6-c6f6-4b8f-9e28-626e0f413c14"), new Guid("769970f3-2b39-4721-a760-acdf92b1911a"), new Guid("d719f312-1d6b-4b99-85b6-31f90e365775") },
                    { new Guid("4140734c-afc1-4dba-8059-0b5f7c89f89c"), new Guid("8991476c-003a-4aec-bb11-ee834367f987"), new Guid("d719f312-1d6b-4b99-85b6-31f90e365775") },
                    { new Guid("6183d11b-170a-4ee7-b715-1afcdc37aceb"), new Guid("8991476c-003a-4aec-bb11-ee834367f987"), new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5") },
                    { new Guid("7d8078bc-55bd-4b6c-8892-b93cffc1fadf"), new Guid("769970f3-2b39-4721-a760-acdf92b1911a"), new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5") },
                    { new Guid("b3d56158-1377-4846-ad8b-4b042be39e54"), new Guid("132240b8-3603-45a3-bf4b-ffdaaab402ad"), new Guid("d719f312-1d6b-4b99-85b6-31f90e365775") },
                    { new Guid("cf6c4c61-9740-4b01-8a4d-e5c3b261169a"), new Guid("132240b8-3603-45a3-bf4b-ffdaaab402ad"), new Guid("b8e17611-767d-4b2a-a9dc-e8914572b153") },
                    { new Guid("d4465959-2ce6-46e9-b1a8-ce1aa0236c19"), new Guid("2696e840-a6b2-4f30-9c9c-c1503863f534"), new Guid("cbb8d327-0615-493c-870d-1e50d3ebafe5") },
                    { new Guid("dc7cb3d9-aa5b-47fa-840c-0fd82552e348"), new Guid("2696e840-a6b2-4f30-9c9c-c1503863f534"), new Guid("d719f312-1d6b-4b99-85b6-31f90e365775") }
                });
        }
    }
}
