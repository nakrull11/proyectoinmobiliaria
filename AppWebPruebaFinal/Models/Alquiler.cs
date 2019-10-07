using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public class Alquiler
    {
        [Key]
        public int IdAlquiler { get; set; }
        
        public decimal Precio { get; set; }
        
        public string FechaInicio { get; set; }
        
        public string FechaFin { get; set; }
        
        public int InquilinoId { get; set; }
        
        public int InmuebleId { get; set; }

    }
}
