using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiGIn.Models.Entities
{
    public interface BaseEntity
    {
        [Key]
        int Id { get; set; }

        DateTime DateUpdated { get; set; }
        DateTime DateCreated { get; set; }
    }
}
