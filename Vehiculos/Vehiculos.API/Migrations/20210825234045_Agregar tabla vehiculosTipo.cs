using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehiculos.API.Migrations
{
    public partial class AgregartablavehiculosTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculosTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosTipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosTipo_Descripcion",
                table: "VehiculosTipo",
                column: "Descripcion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculosTipo");
        }
    }
}
