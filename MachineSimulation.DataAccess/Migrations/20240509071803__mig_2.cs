using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class _mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 14,
                column: "ModbusIp",
                value: 4206);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 18,
                column: "ModbusIp",
                value: 4206);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 22,
                column: "ModbusIp",
                value: 4206);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 14,
                column: "ModbusIp",
                value: 4249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 18,
                column: "ModbusIp",
                value: 4249);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 22,
                column: "ModbusIp",
                value: 4249);
        }
    }
}
