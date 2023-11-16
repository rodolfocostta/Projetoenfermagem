using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnfermariaSenac.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_Enfermagem",
                table: "Prontuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome_Paciente",
                table: "Prontuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome_Enfermagem",
                table: "Prontuario");

            migrationBuilder.DropColumn(
                name: "Nome_Paciente",
                table: "Prontuario");
        }
    }
}
