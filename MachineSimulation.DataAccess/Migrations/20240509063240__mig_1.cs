using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class _mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(type: "TEXT", nullable: false),
                    MachineType = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ModbusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationName = table.Column<string>(type: "TEXT", nullable: false),
                    ModbusIp = table.Column<int>(type: "INTEGER", nullable: true),
                    Event = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterName = table.Column<string>(type: "TEXT", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoppages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReasonStoppageName = table.Column<string>(type: "TEXT", nullable: true),
                    ReasonStoppageValue = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoppages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stoppages_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationParameters_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationParameters_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                values: new object[] { 1, 1, 1, 2280, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 2, 2, 1, 2280, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 3, 3, 1, 2273, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 4, 4, 1, 2273, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 5, 1, 2, 2281, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 6, 2, 2, 2281, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 7, 3, 2, 2274, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 8, 4, 2, 2274, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 9, 1, 3, 2282, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 10, 2, 3, 2282, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 11, 3, 3, 2275, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 12, 4, 3, 2275, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 13, 5, 1, null, "Otomatik Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 14, 6, 1, 4249, "Otomatik Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 15, 7, 1, 2280, "Duruş Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 16, 8, 1, 2280, "Duruş Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 17, 5, 2, null, "Otomatik Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 18, 6, 2, 4249, "Otomatik Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 19, 7, 2, 2280, "Duruş Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 20, 8, 2, 2280, "Duruş Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 21, 5, 3, null, "Otomatik Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 22, 6, 3, 4249, "Otomatik Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 23, 7, 3, 2280, "Duruş Başlat" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Event", "MachineId", "ModbusIp", "OperationName" },
                values: new object[] { 24, 8, 3, 2280, "Duruş Bitir" });

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

            migrationBuilder.InsertData(
                table: "Stoppages",
                columns: new[] { "Id", "MachineId", "ReasonStoppageName", "ReasonStoppageValue" },
                values: new object[] { 1, 1, "Bakım Arıza", 45 });

            migrationBuilder.InsertData(
                table: "Stoppages",
                columns: new[] { "Id", "MachineId", "ReasonStoppageName", "ReasonStoppageValue" },
                values: new object[] { 2, 1, "Planlı Duruş", 60 });

            migrationBuilder.InsertData(
                table: "Stoppages",
                columns: new[] { "Id", "MachineId", "ReasonStoppageName", "ReasonStoppageValue" },
                values: new object[] { 3, 1, "Deneme Duruşu", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameters_OperationId",
                table: "OperationParameters",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameters_ParameterId",
                table: "OperationParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_MachineId",
                table: "Operations",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_MachineId",
                table: "Parameters",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoppages_MachineId",
                table: "Stoppages",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineLogs");

            migrationBuilder.DropTable(
                name: "OperationLogs");

            migrationBuilder.DropTable(
                name: "OperationParameters");

            migrationBuilder.DropTable(
                name: "Stoppages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
