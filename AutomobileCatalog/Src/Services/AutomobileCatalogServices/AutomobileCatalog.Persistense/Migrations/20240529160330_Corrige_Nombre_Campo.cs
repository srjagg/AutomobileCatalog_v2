using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobileCatalog.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class Corrige_Nombre_Campo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Cars",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Cars",
                newName: "Descripción");
        }
    }
}
