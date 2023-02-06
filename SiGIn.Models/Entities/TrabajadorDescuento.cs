using System;

namespace SiGIn.Models.Entities
{
    public class TrabajadorDescuento : BaseEntity
    {
        public int Id { get; set; }
        public int? TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }
        public int? TipoDescuentoId { get; set; }
        public TipoDescuento TipoDescuento { get; set; }
        public int? Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}