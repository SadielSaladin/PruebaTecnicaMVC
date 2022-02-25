using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre_Estado { get; set; }
        [Required]
        public DateTime Fecha_Creacion { get; set; }
    }
}
