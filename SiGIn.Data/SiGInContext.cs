using Microsoft.EntityFrameworkCore;
using SiGIn.Models.Entities;

namespace SiGIn.Data
{
    public partial class SiGInContext : DbContext
    {
        public SiGInContext(DbContextOptions<SiGInContext> options) : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Auxiliar> Auxiliar { get; set; }
        public virtual DbSet<AuxiliarFemenino> AuxiliarFemenino { get; set; }
        public virtual DbSet<TipoDescuento> TipoDescuento { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Nomina> Nomina { get; set; }
        public virtual DbSet<PedProdTalla> PedProdTalla { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TrabajadorDescuento> TrabajadorDescuento { get; set; }
        public virtual DbSet<Talla> Talla { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}