using System;

namespace SiGIn.Models.Entities
{
    public class Trabajador : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Ni { get; set; }
        public string ActividadDesempeña { get; set; }
        public bool Contratado { get; set; }
        public string ContratadoPor { get; set; }
        public int? NoRegistroCreador { get; set; }
        public DateTime? FehaExpedicionTcp { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}