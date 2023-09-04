using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateManagemente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creating_UserId_for_candidates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_User_IdUser",
                table: "Candidates",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_candidates_IdCandidate",
                table: "Experiences",
                column: "IdCandidate",
                principalTable: "candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
