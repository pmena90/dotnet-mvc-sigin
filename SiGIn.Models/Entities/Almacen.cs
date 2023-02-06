using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Almacen : BaseEntity
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public int? IdTalla { get; set; }
        public int? CantidadEntrada { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public int? CantidadSalida { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int? Total { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}