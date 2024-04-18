using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class seedData_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModbusIp",
                value: 2250);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModbusIp",
                value: 2250);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ModbusIp",
                value: 2256);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ModbusIp",
                value: 2256);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 9,
                column: "ModbusIp",
                value: 2251);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 10,
                column: "ModbusIp",
                value: 2251);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 11,
                column: "ModbusIp",
                value: 2257);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 12,
                column: "ModbusIp",
                value: 2257);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModbusIp",
                value: 4249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModbusIp",
                value: 4249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModbusIp",
                value: 4255);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModbusIp",
                value: 4255);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModbusIp",
                value: 4250);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModbusIp",
                value: 4250);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ModbusIp",
                value: 4256);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ModbusIp",
                value: 4256);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 9,
                column: "ModbusIp",
                value: 4251);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 10,
                column: "ModbusIp",
                value: 4251);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 11,
                column: "ModbusIp",
                value: 4257);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 12,
                column: "ModbusIp",
                value: 4257);
        }
    }
}
