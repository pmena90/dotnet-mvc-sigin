using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Producto : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public string Um { get; set; }
        public decimal PrecioUnitarioCuc { get; set; }
        public decimal PrecioUnitarioCup { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}