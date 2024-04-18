using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModbusIp",
                value: 2218);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModbusIp",
                value: 2218);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModbusIp",
                value: 2219);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModbusIp",
                value: 2219);
        }
    }
}
