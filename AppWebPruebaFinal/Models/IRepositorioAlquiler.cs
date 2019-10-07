using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public interface IRepositorioAlquiler : IRepositorio<Alquiler>
    {
        Alquiler ObtenerPorInmueble(int id);
        Alquiler ObtenerPorInquilino(int id);

        

    }
}
