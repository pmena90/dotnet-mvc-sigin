using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class PedProdTalla : BaseEntity
    {
        public int Id { get; set; }
        public string NoPedido { get; set; }
        public int? IdProducto { get; set; }
        public int? IdTalla { get; set; }
        public int? Cantidad { get; set; }
        public int? CantEnteros { get; set; }
        public int? Vendidos { get; set; }
        public int? PorVender { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}