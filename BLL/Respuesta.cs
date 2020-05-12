using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class Respuesta
    {
        public string Mensaje { get; set; }
        public TipoMensaje Tipo { get; set; }
    }

    public class RespuestaDeConsulta : Respuesta
    {
        public IList<Consignacion> Consignaciones { get; set; }
    }

    public class RespuestaDeBusqueda : Respuesta
    {
        public Consignacion Consignacion { get; set; }
    }
}
