using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public class RepositorioInquilino : RepositorioBase, IRepositorio<Inquilino>
    {
        public RepositorioInquilino(IConfiguration configuration) : base(configuration)
        {

        }
        public int Alta(Inquilino p)
        {
            throw new NotImplementedException();
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(Inquilino p)
        {
            throw new NotImplementedException();
        }

        public Inquilino ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Inquilino> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
