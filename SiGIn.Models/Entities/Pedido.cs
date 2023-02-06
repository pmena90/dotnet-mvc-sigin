using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Pedido : BaseEntity
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public int? IdEmpresa { get; set; }
        public int? CantidadPedido { get; set; }
        public string NoPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public bool Abierto { get; set; }
        public int? Vendidos { get; set; }
        public int? PorVender { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}