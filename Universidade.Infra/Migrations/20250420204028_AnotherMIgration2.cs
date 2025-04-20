using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universidade.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AnotherMIgration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "LimiteParticipantes",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "TemLimite",
                table: "Eventos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimiteParticipantes",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TemLimite",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Eventos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
