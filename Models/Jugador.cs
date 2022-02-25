using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Models
{
    public class Jugador
    {
        public int Id { get; set; }
       
        public string Nombre { get; set; }
      
        public string Apellido { get; set; }
       
        public DateTime Fecha_Nacimiento { get; set; }
      
        public string Pasporte { get; set; }
        public string Direccion { get; set; }
     
        public char Sexo { get; set; }
        [Required]
        public int Estado_id { get; set; }

        [ForeignKey("Estado_id")]
        public virtual Estado Estado { get; set; }
    }
}
