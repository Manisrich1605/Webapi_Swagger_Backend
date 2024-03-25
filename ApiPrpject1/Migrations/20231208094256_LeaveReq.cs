using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPrpject1.Migrations
{
    /// <inheritdoc />
    public partial class LeaveReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "RequestingEmployeeId",
                table: "LeaveRequests",
                newName: "LeaveType");

            migrationBuilder.AlterColumn<string>(
                name: "Approved",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "LeaveType",
                table: "LeaveRequests",
                newName: "RequestingEmployeeId");

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "LeaveRequests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "LeaveRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
