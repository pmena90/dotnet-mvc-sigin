using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiGIn.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(nullable: true),
                    IdTalla = table.Column<int>(nullable: true),
                    CantidadEntrada = table.Column<int>(nullable: true),
                    FechaEntrada = table.Column<DateTime>(nullable: true),
                    CantidadSalida = table.Column<int>(nullable: true),
                    FechaSalida = table.Column<DateTime>(nullable: true),
                    Total = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auxiliar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: true),
                    Producto = table.Column<string>(nullable: true),
                    Talla = table.Column<string>(nullable: true),
                    CantPedidos = table.Column<int>(nullable: true),
                    CantProceso = table.Column<int>(nullable: true),
                    PorCortar = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auxiliar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuxiliarFemenino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Totales = table.Column<string>(nullable: true),
                    F3525 = table.Column<int>(nullable: true),
                    F363 = table.Column<int>(nullable: true),
                    F384 = table.Column<int>(nullable: true),
                    F405 = table.Column<int>(nullable: true),
                    F426 = table.Column<int>(nullable: true),
                    F447 = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuxiliarFemenino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true),
                    DomicilioLegal = table.Column<string>(nullable: true),
                    CodigoReeup = table.Column<string>(nullable: true),
                    CodigoNit = table.Column<string>(nullable: true),
                    CuentaBancariaCuc = table.Column<string>(nullable: true),
                    AgenciaBancariaCuc = table.Column<string>(nullable: true),
                    CuentaBancariaCup = table.Column<string>(nullable: true),
                    AgenciaBancariaCup = table.Column<string>(nullable: true),
                    Representante = table.Column<string>(nullable: true),
                    ResolucionNo = table.Column<string>(nullable: true),
                    FechaResolucion = table.Column<DateTime>(nullable: true),
                    DictadaPor = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTrabajador = table.Column<int>(nullable: true),
                    IdPedido = table.Column<string>(nullable: true),
                    IdActividad = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: true),
                    IdTalla = table.Column<int>(nullable: true),
                    IdProducto = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    CantidadPedido = table.Column<int>(nullable: true),
                    NoPedido = table.Column<string>(nullable: true),
                    FechaPedido = table.Column<DateTime>(nullable: true),
                    Abierto = table.Column<bool>(nullable: false),
                    Vendidos = table.Column<int>(nullable: true),
                    PorVender = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedProdTalla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoPedido = table.Column<string>(nullable: true),
                    IdProducto = table.Column<int>(nullable: true),
                    IdTalla = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    CantEnteros = table.Column<int>(nullable: true),
                    Vendidos = table.Column<int>(nullable: true),
                    PorVender = table.Column<int>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedProdTalla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Um = table.Column<string>(nullable: true),
                    PrecioUnitarioCuc = table.Column<decimal>(nullable: true),
                    PrecioUnitarioCup = table.Column<decimal>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Ni = table.Column<string>(nullable: true),
                    ActividadDesempeña = table.Column<string>(nullable: true),
                    Contratado = table.Column<bool>(nullable: false),
                    ContratadoPor = table.Column<string>(nullable: true),
                    NoRegistroCreador = table.Column<int>(nullable: true),
                    FehaExpedicionTcp = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrabajadorDescuento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrabajadorId = table.Column<int>(nullable: true),
                    DescuentoId = table.Column<int>(nullable: true),
                    Monto = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Auxiliar");

            migrationBuilder.DropTable(
                name: "AuxiliarFemenino");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PedProdTalla");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Talla");

            migrationBuilder.DropTable(
                name: "TrabajadorDescuento");

            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.DropTable(
                name: "Trabajador");
        }
    }
}
