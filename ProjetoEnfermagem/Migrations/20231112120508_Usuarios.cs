using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnfermariaSenac.Migrations
{
    /// <inheritdoc />
    public partial class Usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Usuario",
              columns: table => new
              {
                  IdSenha = table.Column<int>(type: "INTEGER", nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                  Email = table.Column<int>(type: "TEXT", nullable: false),
                  Nome = table.Column<int>(type: "TEXT", nullable: false),
                  Senha = table.Column<string>(type: "TEXT", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Usuario", x => x.IdSenha);
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

          
        }
    }

}
