using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Actividad : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}