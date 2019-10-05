using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public class Inquilino
    {
        public int IdInquilino { get; set; }
        public String Nombre { get; set; }
        public String Dni { get; set; }
        public int IdInmuebleAlquilado { get; set; }
    }
}
