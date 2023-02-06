using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiGIn.Models.TipoDescuento
{
    public class TipoDescuentoUpdateVM
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }
    }
}