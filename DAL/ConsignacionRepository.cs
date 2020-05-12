using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class ConsignacionRepository
    {
        private string ruta = @"PagosBanco.txt";
        public IList<Consignacion> consignaciones;

        public ConsignacionRepository()
        {
            this.consignaciones = new List<Consignacion>();
            this.consignaciones = Consultar();
        }

        public void Guardar(Consignacion consignacion)
        {
            FileStream fileStream = new FileStream(this.ruta, FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            string linea = $"{consignacion.EntidadDeServicios.ToString()};{consignacion.NumeroDeRecibo};" +
                           $"{consignacion.FechaDePago.ToString("dd/MM/yyyy")};{consignacion.ValorPagado}";
            stream.WriteLine(linea);
            stream.Close();
            fileStream.Close();
        }

        public IList<Consignacion> Consultar()
        {
            this.consignaciones.Clear();
            FileStream fileStream = new FileStream(this.ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(fileStream);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Consignacion consignacion = this.MapearConsignacion(linea);
                this.consignaciones.Add(consignacion);
            }
            lector.Close();
            fileStream.Close();
            return this.consignaciones;
        }

        public Consignacion MapearConsignacion(string linea)
        {
            Consignacion consignacion = new Consignacion();
            string[] datos = linea.Split(';');
            consignacion.EntidadDeServicios = (Entidad) Enum.Parse(typeof(Entidad),datos[0]);
            consignacion.NumeroDeRecibo = Convert.ToInt32( datos[1]);
            consignacion.FechaDePago = DateTime.Parse(datos[2]);
            consignacion.ValorPagado = double.Parse( datos[3]);
            return consignacion;
        }

        public Consignacion Buscar(int numeroDeRecibo)
        {
            this.consignaciones.Clear();
            this.consignaciones = Consultar();
            Consignacion consignacion = new Consignacion();
            foreach (var element in this.consignaciones)
            {
                if (element.NumeroDeRecibo.Equals(numeroDeRecibo))
                {
                    return element;
                }
            }
            return null;
        }

        public int TotalizarConsignaciones()
        {
            return this.consignaciones.Count();
        }

        public int TotalizarPorTipo(Entidad tipo)
        {
            return this.consignaciones.Where(c => c.EntidadDeServicios == tipo).Count();
        }

        public IList<Consignacion> ListarPorTipo(Entidad tipo)
        {
            return this.consignaciones.Where(c => c.EntidadDeServicios == tipo).ToList();
        }

        public double TotalRecaudado()
        {
            double total = 0;
            foreach (var element in this.consignaciones)
            {
                total += element.ValorPagado;
            }
            return total;
        }

        public double TotalRecaudadoPorEntidad(Entidad entidad)
        {
            double total = 0;
            foreach (var element in this.consignaciones)
            {
                if (element.EntidadDeServicios == entidad)
                {
                    total += element.ValorPagado;
                }
            }
            return total;
        }

    }
}
