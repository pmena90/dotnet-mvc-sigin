using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiGIn.Models.TipoDescuento
{
    public class TipoDescuentoVM : BaseVM
    {

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }
    }
}
