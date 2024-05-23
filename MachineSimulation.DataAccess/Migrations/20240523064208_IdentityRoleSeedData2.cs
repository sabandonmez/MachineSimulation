using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class IdentityRoleSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1a48f6f-63f6-4bc1-86fd-3fcb5c609fac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43503319-8dec-405d-9425-a28f080bb5ad", "dd7d4460-d233-49f5-94be-0be281574772", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43503319-8dec-405d-9425-a28f080bb5ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1a48f6f-63f6-4bc1-86fd-3fcb5c609fac", "85865092-6af8-47dd-8ed3-bd1ff50e1a2a", "Admin", "ADMIN" });
        }
    }
}
