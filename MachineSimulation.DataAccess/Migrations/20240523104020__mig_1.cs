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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33911f39-fa54-4ebf-b0ac-f2bd173e135e", "d616e946-9b32-454d-8426-e11647c446c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a7d51b1-3fcf-4891-85e2-4e11ef55412d", "20e27af1-1861-4c24-8002-e0d5917c120f", "Editor", "EDITOR" });

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MachineLogs");

            migrationBuilder.DropTable(
                name: "OperationLogs");

            migrationBuilder.DropTable(
                name: "OperationParameters");

            migrationBuilder.DropTable(
                name: "Stoppages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
