using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public class Alquiler
    {
        public int IdAlquiler { get; set; }
        public int IdInmueble { get; set; }
        public DateTime FechaAlquilado { get; set; }
    }
}
