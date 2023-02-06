using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiGIn.Models
{
    public abstract class BaseVM
    {
        public int Id { get; set; }

        [DisplayName("Actualizado")]
        public string DateUpdated { get; set; }

        [DisplayName("Creado")]
        public string DateCreated { get; set; }
    }
}
