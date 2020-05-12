using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class ExportacionService
    {
        private ExportarRepository exportarRepository;
        public ExportacionService()
        {
            exportarRepository = new ExportarRepository();
        }
        public Respuesta ExportarConsignacion(Exportacion exportacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                exportarRepository.Exportar(exportacion);
                respuesta.Mensaje = "Se exporto de forma correcta";
                respuesta.Tipo = TipoMensaje.INFORMACION;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error de lectura o escritura de archivos: " + ex.Message;
                respuesta.Tipo = TipoMensaje.ERROR;
                return respuesta;
            }
        }
    }
}
