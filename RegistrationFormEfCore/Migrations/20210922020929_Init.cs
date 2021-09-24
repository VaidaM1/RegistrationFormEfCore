using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationFormEfCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropDownOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropDownOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedValues",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    DropDownOptionId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedValues", x => new { x.QuestionId, x.DropDownOptionId });
                    table.ForeignKey(
                        name: "FK_SelectedValues_DropDownOptions_DropDownOptionId",
                        column: x => x.DropDownOptionId,
                        principalTable: "DropDownOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedValues_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropDownOptions_QuestionId",
                table: "DropDownOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedValues_DropDownOptionId",
                table: "SelectedValues",
                column: "DropDownOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedValues");

            migrationBuilder.DropTable(
                name: "DropDownOptions");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
