using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class nee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentasCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITEM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    CLIENTE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOTAL_CLIENTE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    BebidaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasCliente_Bebidas_BebidaID",
                        column: x => x.BebidaID,
                        principalTable: "Bebidas",
                        principalColumn: "IDbebida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasCliente_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentasCliente_BebidaID",
                table: "VentasCliente",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_VentasCliente_UsuarioID",
                table: "VentasCliente",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasCliente");
        }
    }
}
