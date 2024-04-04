using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModbusId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModbusId",
                table: "Machines");
        }
    }
}
