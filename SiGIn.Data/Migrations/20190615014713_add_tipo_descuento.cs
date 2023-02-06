using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiGIn.Data.Migrations
{
    public partial class add_tipo_descuento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "TipoDescuento",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "TrabajadorDescuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrabajadorId = table.Column<int>(nullable: true),
                    TipoDescuentoId = table.Column<int>(nullable: true),
                    Monto = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadorDescuento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajadorDescuento_TipoDescuento_TipoDescuentoId",
                        column: x => x.TipoDescuentoId,
                        principalTable: "TipoDescuento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorDescuento_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDescuento_TipoDescuentoId",
                table: "TrabajadorDescuento",
                column: "TipoDescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDescuento_TrabajadorId",
                table: "TrabajadorDescuento",
                column: "TrabajadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrabajadorDescuento");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TipoDescuento",
                newName: "Descripcion");

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DescuentoId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: true),
                    Monto = table.Column<int>(nullable: true),
                    TipoDescuentoId = table.Column<int>(nullable: true),
                    TrabajadorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descuento_TipoDescuento_TipoDescuentoId",
                        column: x => x.TipoDescuentoId,
                        principalTable: "TipoDescuento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Descuento_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descuento_TipoDescuentoId",
                table: "Descuento",
                column: "TipoDescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Descuento_TrabajadorId",
                table: "Descuento",
                column: "TrabajadorId");
        }
    }
}
