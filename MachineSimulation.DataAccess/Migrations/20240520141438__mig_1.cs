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
                name: "OperationNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationNames", x => x.Id);
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
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterName = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationNameId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModbusIp = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Operations_OperationNames_OperationNameId",
                        column: x => x.OperationNameId,
                        principalTable: "OperationNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "ImageUrl", "MachineName", "ModbusId" },
                values: new object[] { 1, "PlastikEnjeksiyon.jpg", "Plastik Enjeksiyon", 4096 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "ImageUrl", "MachineName", "ModbusId" },
                values: new object[] { 2, "KitamuraCncTezgahı.jpg", "Kitamura Cnc Tezgahı", 4097 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "ImageUrl", "MachineName", "ModbusId" },
                values: new object[] { 3, "AbkantPress.jpg", "Abkant Press", 4098 });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Hazırlık Başlat" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Hazırlık Bitir" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Otomatik Üretim Başlat" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Otomatik Üretim Bitir" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Duruş Başlat" });

            migrationBuilder.InsertData(
                table: "OperationNames",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Duruş Bitir" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 1, 1, 2280, 1 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 2, 1, 2280, 2 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 3, 1, 2273, 3 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 4, 1, 2273, 4 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 5, 2, 2281, 1 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 6, 2, 2281, 2 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 7, 2, 2274, 3 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 8, 2, 2274, 4 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 9, 3, 2282, 1 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 10, 3, 2282, 2 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 11, 3, 2275, 3 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 12, 3, 2275, 4 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 13, 1, null, 5 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 14, 1, 4206, 6 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 15, 1, 2280, 7 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 16, 1, 2280, 8 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 17, 2, null, 5 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 18, 2, 4206, 6 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 19, 2, 2280, 7 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 20, 2, 2280, 8 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 21, 3, null, 5 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 22, 3, 4206, 6 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 23, 3, 2280, 7 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "MachineId", "ModbusIp", "OperationNameId" },
                values: new object[] { 24, 3, 2280, 8 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 1, 1, "Hız" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 2, 2, "Hız" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 3, 1, "Sıcaklık" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 4, 2, "Sıcaklık" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 5, 3, "Cnc Ilerleme Hizi" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "MachineId", "ParameterName" },
                values: new object[] { 6, 3, "Ariza Alarm Sayisi" });

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
                name: "IX_Operations_OperationNameId",
                table: "Operations",
                column: "OperationNameId");

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
                name: "OperationNames");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
