using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class ExportarRepository
    {

        public string ruta;
        public void Exportar(Exportacion exportacion)
        {
            AsignarRuta(exportacion.Entidad.ToString(), exportacion.FechaDelReporte);
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            string linea1 = $"{exportacion.Entidad};{exportacion.FechaDelReporte.ToString("dd/MM/yyyy")}";
            string linea2 = $"{exportacion.TotalRecaudado};{exportacion.CantidadDePagos}";
            this.Guardar(linea1);
            this.Guardar(linea2);
            foreach (var element in exportacion.consignaciones)
            {
                string linea = $"{element.NumeroDeRecibo};{element.FechaDePago.ToString("dd/MM/yyyy")};{element.ValorPagado}"; 
                this.Guardar(linea);
            }
        }

        public void Guardar(string linea)
        {
            FileStream fileStream = new FileStream(this.ruta, FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine(linea);
            stream.Close();
            fileStream.Close();
        }

        public void AsignarRuta(string Entidad, DateTime fecha)
        {
            string path = Entidad.ToUpper() + fecha.ToString("ddMMyyyy")+".txt" ;
            this.ruta = path;
        }
    }
}
