using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universidade.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AOOOOOPOTENCIA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Usuarios",
                newName: "Followers");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios",
                newName: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Followers",
                table: "Usuarios",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Usuarios",
                newName: "Cpf");

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
