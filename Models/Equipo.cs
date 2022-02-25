using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Models
{
    public class Equipo
    {
       
        public int Id { get; set; }
       
        public string Nombre { get; set; }
      
        public string Pais { get; set; }

        public int EstadoID { get; set; }

        public Estado Estado { get; set; }

        public DateTime Fecha_Creacion { get; set; }
    }
}
