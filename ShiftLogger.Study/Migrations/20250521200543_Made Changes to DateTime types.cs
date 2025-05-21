using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLogger.Study.Migrations
{
    /// <inheritdoc />
    public partial class MadeChangestoDateTimetypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShiftStartTime",
                table: "Shifts",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShiftEndTime",
                table: "Shifts",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShiftStartTime",
                table: "Shifts",
                type: "Time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShiftEndTime",
                table: "Shifts",
                type: "Time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
