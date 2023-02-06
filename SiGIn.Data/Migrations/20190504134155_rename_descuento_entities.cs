using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiGIn.Data.Migrations
{
    public partial class rename_descuento_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrabajadorDescuento");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Descuento");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioCup",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioCuc",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DescuentoId",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Monto",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDescuentoId",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrabajadorId",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Actividad",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TipoDescuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDescuento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descuento_TipoDescuentoId",
                table: "Descuento",
                column: "TipoDescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Descuento_TrabajadorId",
                table: "Descuento",
                column: "TrabajadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descuento_TipoDescuento_TipoDescuentoId",
                table: "Descuento",
                column: "TipoDescuentoId",
                principalTable: "TipoDescuento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descuento_Trabajador_TrabajadorId",
                table: "Descuento",
                column: "TrabajadorId",
                principalTable: "Trabajador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descuento_TipoDescuento_TipoDescuentoId",
                table: "Descuento");

            migrationBuilder.DropForeignKey(
                name: "FK_Descuento_Trabajador_TrabajadorId",
                table: "Descuento");

            migrationBuilder.DropTable(
                name: "TipoDescuento");

            migrationBuilder.DropIndex(
                name: "IX_Descuento_TipoDescuentoId",
                table: "Descuento");

            migrationBuilder.DropIndex(
                name: "IX_Descuento_TrabajadorId",
                table: "Descuento");

            migrationBuilder.DropColumn(
                name: "DescuentoId",
                table: "Descuento");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Descuento");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Descuento");

            migrationBuilder.DropColumn(
                name: "TipoDescuentoId",
                table: "Descuento");

            migrationBuilder.DropColumn(
                name: "TrabajadorId",
                table: "Descuento");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioCup",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioCuc",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Descuento",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Actividad",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateTable(
                name: "TrabajadorDescuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DescuentoId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: true),
                    Monto = table.Column<int>(nullable: true),
                    TrabajadorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadorDescuento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajadorDescuento_Descuento_DescuentoId",
                        column: x => x.DescuentoId,
                        principalTable: "Descuento",
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
                name: "IX_TrabajadorDescuento_DescuentoId",
                table: "TrabajadorDescuento",
                column: "DescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDescuento_TrabajadorId",
                table: "TrabajadorDescuento",
                column: "TrabajadorId");
        }
    }
}
