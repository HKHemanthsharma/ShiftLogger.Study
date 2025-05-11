using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLogger.Study.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Wrokers_WorkerId",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wrokers",
                table: "Wrokers");

            migrationBuilder.RenameTable(
                name: "Wrokers",
                newName: "Workers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Workers_WorkerId",
                table: "Shifts",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Workers_WorkerId",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Wrokers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wrokers",
                table: "Wrokers",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Wrokers_WorkerId",
                table: "Shifts",
                column: "WorkerId",
                principalTable: "Wrokers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
