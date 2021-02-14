using Microsoft.EntityFrameworkCore.Migrations;

namespace Practica.Server.Migrations
{
    public partial class databasePR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id_Ciudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCiudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id_Ciudad);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSucursal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DireccionSucursal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Comuna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.IdSucursal);
                });

            migrationBuilder.CreateTable(
                name: "Comunas",
                columns: table => new
                {
                    Id_Comuna = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Ciudad = table.Column<int>(type: "int", nullable: false),
                    CiudadId_Ciudad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunas", x => x.Id_Comuna);
                    table.ForeignKey(
                        name: "FK_Comunas_Ciudades_CiudadId_Ciudad",
                        column: x => x.CiudadId_Ciudad,
                        principalTable: "Ciudades",
                        principalColumn: "Id_Ciudad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodegas",
                columns: table => new
                {
                    ID_Bodega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreBodega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Sucursal = table.Column<int>(type: "int", nullable: false),
                    SucursalIdSucursal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.ID_Bodega);
                    table.ForeignKey(
                        name: "FK_Bodegas_Sucursales_SucursalIdSucursal",
                        column: x => x.SucursalIdSucursal,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id_Ciudad", "NombreCiudad" },
                values: new object[] { 1, "Antofagasta" });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id_Ciudad", "NombreCiudad" },
                values: new object[] { 2, "Calama" });

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_SucursalIdSucursal",
                table: "Bodegas",
                column: "SucursalIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_CiudadId_Ciudad",
                table: "Comunas",
                column: "CiudadId_Ciudad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropTable(
                name: "Comunas");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
