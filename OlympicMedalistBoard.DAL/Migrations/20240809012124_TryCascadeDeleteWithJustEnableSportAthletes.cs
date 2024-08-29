using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicMedalistBoard.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TryCascadeDeleteWithJustEnableSportAthletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Medals_Sports_SportID",
            //    table: "Medals");

            migrationBuilder.AddForeignKey(
                name: "FK_Medals_Sports_SportID",
                table: "Medals",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medals_Sports_SportID",
                table: "Medals");

            migrationBuilder.AddForeignKey(
                name: "FK_Medals_Sports_SportID",
                table: "Medals",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
