using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Auxiliar : BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Producto { get; set; }
        public string Talla { get; set; }
        public int? CantPedidos { get; set; }
        public int? CantProceso { get; set; }
        public int? PorCortar { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}