using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Nomina : BaseEntity
    {
        public int Id { get; set; }
        public int? IdTrabajador { get; set; }
        public string IdPedido { get; set; }
        public int? IdActividad { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTalla { get; set; }
        public int? IdProducto { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}