using System;
using System.Collections.Generic;

namespace SiGIn.Models.Entities
{ 
    public class AuxiliarFemenino : BaseEntity
    {
        public int Id { get; set; }
        public string Totales { get; set; }
        public int? F3525 { get; set; }
        public int? F363 { get; set; }
        public int? F384 { get; set; }
        public int? F405 { get; set; }
        public int? F426 { get; set; }
        public int? F447 { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}