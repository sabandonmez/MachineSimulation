using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModbusIp",
                value: 2222);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModbusIp",
                value: 2222);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModbusIp",
                value: 2249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModbusIp",
                value: 2249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModbusIp",
                value: 2255);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModbusIp",
                value: 2255);
        }
    }
}
