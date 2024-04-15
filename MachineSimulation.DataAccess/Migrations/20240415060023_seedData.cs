using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "ImageUrl", "MachineName", "MachineType", "ModbusId", "ProductionCount" },
                values: new object[] { 1, "PlastikEnjeksiyon.jpg", "Plastik Enjeksiyon", "enjeksiyon", 4096, 0 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "ImageUrl", "MachineName", "MachineType", "ModbusId", "ProductionCount" },
                values: new object[] { 2, "KitamuraCncTezgahı.jpg", "Kitamura Cnc Tezgahı", "cnc", 4097, 0 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "ImageUrl", "MachineName", "MachineType", "ModbusId", "ProductionCount" },
                values: new object[] { 3, "AbkantPress.jpg", "Abkant Press", "press", 4098, 0 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 1, 1, 1, 4249, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 2, 2, 1, 4249, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 3, 3, 1, 4255, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 4, 4, 1, 4255, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 5, 1, 2, 4250, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 6, 2, 2, 4250, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 7, 3, 2, 4256, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 8, 4, 2, 4256, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 9, 1, 3, 4251, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 10, 2, 3, 4251, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 11, 3, 3, 4257, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 12, 4, 3, 4257, "Üretim Bitir" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
