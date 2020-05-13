using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class ConsignacionService
    {
        public static ConsignacionRepository consignacionRepository = new ConsignacionRepository();

        public Respuesta Guardar(Consignacion consignacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (consignacionRepository.Buscar(consignacion.NumeroDeRecibo) == null)
                {
                    consignacionRepository.Guardar(consignacion);
                    respuesta.Mensaje = "Se registro la consignación de forma exitosa";
                    respuesta.Tipo = TipoMensaje.INFORMACION;
                    return respuesta;
                }
                respuesta.Mensaje = $"El numero de cuenta {consignacion.NumeroDeRecibo} ya ha sigo registrado";
                respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "ERROR EN LOS DATOS: " + ex.Message; 
                respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                return respuesta;
            }
        }

        public RespuestaDeBusqueda Buscar(int NumeroDeRecibo)
        {
            RespuestaDeBusqueda respuesta = new RespuestaDeBusqueda();
            try
            {
                Consignacion consignacion = consignacionRepository.Buscar(NumeroDeRecibo);
                respuesta.Consignacion = consignacion;
                if (consignacion == null)
                {
                    respuesta.Mensaje = "No existe ningún recibo de consignación con este número de recibo :" +NumeroDeRecibo;
                    respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                }
                else
                {
                    respuesta.Mensaje = "Se encontro la consignación";
                    respuesta.Tipo = TipoMensaje.INFORMACION;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error de lectura o escritura de archivos: " + ex.Message;
                respuesta.Consignacion = null;
                respuesta.Tipo =TipoMensaje.ERROR;
            }
            return respuesta;
        }

        public RespuestaDeConsulta Consultar()
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            try
            {
                IList<Consignacion> consignaciones = consignacionRepository.Consultar();
                respuesta.Consignaciones = consignaciones;
                if (consignaciones.Count == 0)
                {
                    respuesta.Mensaje = "No hay consignaciones registradas";
                    respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                }
                else
                {
                    respuesta.Mensaje = "Consignaciones consultadas";
                    respuesta.Tipo = TipoMensaje.INFORMACION;
                }

            }
            catch (Exception ex)
            {
                respuesta.Tipo = TipoMensaje.ERROR;
                respuesta.Mensaje = "Erro en datos: " + ex.Message;
                respuesta.Consignaciones = null;
            }
            return respuesta;

        }

        public int TotalizarPorTipo(Entidad entidad)
        {
            return consignacionRepository.TotalizarPorTipo(entidad);
        }

        public RespuestaDeConsulta ConsultarPorTipo(Entidad entidad)
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            try
            {
                IList<Consignacion> consignaciones = consignacionRepository.ListarPorTipo(entidad);
                respuesta.Consignaciones = consignaciones;
                if (consignaciones.Count == 0)
                {
                    respuesta.Mensaje = $"No hay consignaciones registradas de {entidad}";
                    respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                }
                else
                {
                    respuesta.Mensaje = "Consignaciones consultadas";
                    respuesta.Tipo = TipoMensaje.INFORMACION;
                }

            }
            catch (Exception ex)
            {
                respuesta.Tipo = TipoMensaje.ERROR;
                respuesta.Mensaje = "Erro en datos: " + ex.Message;
                respuesta.Consignaciones = null;
            }
            return respuesta;

        }

        public int TotalizarPorTipoYFecha(Entidad entidad, DateTime fecha)
        {
            return consignacionRepository.TotalizarPorTipoYFecha(entidad, fecha);
        }

        public RespuestaDeConsulta ConsultarPorTipoYFecha(Entidad entidad, DateTime fecha)
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            try
            {
                IList<Consignacion> consignaciones = consignacionRepository.ListarPorTipoYFecha(entidad, fecha);
                respuesta.Consignaciones = consignaciones;
                if (consignaciones.Count == 0)
                {
                    respuesta.Mensaje = $"No hay consignaciones registradas de {entidad} en esta fecha {fecha.ToString("dd/MM/yyyy")}";
                    respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                }
                else
                {
                    respuesta.Mensaje = "Consignaciones consultadas con exito";
                    respuesta.Tipo = TipoMensaje.INFORMACION;
                }

            }
            catch (Exception ex)
            {
                respuesta.Tipo = TipoMensaje.ERROR;
                respuesta.Mensaje = "Erro en datos: " + ex.Message;
                respuesta.Consignaciones = null;
            }
            return respuesta;

        }

        public double TotalRecaudado()
        {
            return consignacionRepository.TotalRecaudado();
        }

        public double TotalRecaudadoPorEntidad(Entidad entidad)
        {
            return consignacionRepository.TotalRecaudadoPorEntidad(entidad);
        }

        public double TotalRecaudadoPorEntidadYFecha(Entidad entidad, DateTime fecha)
        {
            return consignacionRepository.TotalRecaudadoPorEntidadEnUnaFecha(entidad, fecha);
        }
    }
}
