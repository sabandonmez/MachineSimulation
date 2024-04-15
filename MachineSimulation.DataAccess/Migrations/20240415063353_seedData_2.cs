using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class seedData_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 1, 1, "Hız", "int" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 2, 1, "Sıcaklık", "int" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 3, 2, "Hız", "int" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 4, 2, "Sıcaklık", "int" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 5, 3, "Cnc Ilerleme Hizi", "int" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName", "ValueType" },
                values: new object[] { 6, 3, "Ariza Alarm Sayisi", "int" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
