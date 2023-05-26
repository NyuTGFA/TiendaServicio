using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicio.api.CarritoCompras.Migrations
{
    public partial class versionsql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "CarritoSesion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "CarritoSesion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
