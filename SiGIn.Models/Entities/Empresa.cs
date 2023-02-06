using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{
    public class Empresa : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string DomicilioLegal { get; set; }
        public string CodigoReeup { get; set; }
        public string CodigoNit { get; set; }
        public string CuentaBancariaCuc { get; set; }
        public string AgenciaBancariaCuc { get; set; }
        public string CuentaBancariaCup { get; set; }
        public string AgenciaBancariaCup { get; set; }
        public string Representante { get; set; }
        public string ResolucionNo { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string DictadaPor { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}