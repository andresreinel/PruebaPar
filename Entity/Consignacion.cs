using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Consignacion
    { 
        public Entidad EntidadDeServicios { get; set; }

        public int NumeroDeRecibo { get; set; }

        public DateTime FechaDePago { get; set; }

        public double ValorPagado { get; set; }
    }
}
