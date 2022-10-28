using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceAssignment.Infrastracture.Migrations
{
    public partial class NullableFieldInDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Employees_EmployeeId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Devices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Employees_EmployeeId",
                table: "Devices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Employees_EmployeeId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Devices",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Employees_EmployeeId",
                table: "Devices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
