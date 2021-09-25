using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationFormEfCore.Migrations
{
    public partial class registrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedValues_RegistrationId",
                table: "SelectedValues",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedValues_Registrations_RegistrationId",
                table: "SelectedValues",
                column: "RegistrationId",
                principalTable: "Registrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedValues_Registrations_RegistrationId",
                table: "SelectedValues");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_SelectedValues_RegistrationId",
                table: "SelectedValues");
        }
    }
}
