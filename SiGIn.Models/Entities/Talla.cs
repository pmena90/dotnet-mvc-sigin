using System;

namespace SiGIn.Models.Entities
{
    public class Talla : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}