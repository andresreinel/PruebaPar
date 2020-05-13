using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Exportacion
    {
        public Entidad Entidad { get; set; }
        public DateTime FechaDelReporte { get; set; }
        public double TotalRecaudado {get; set;}
        public int CantidadDePagos { get; set; }
        public IList<Consignacion> consignaciones { get; set; }
    }
}
