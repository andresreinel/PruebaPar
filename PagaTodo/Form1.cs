using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PagaTodo
{
    public partial class Form1 : Form
    {
        public List<Consignacion> consignaciones = new List<Consignacion>();
        static Consignacion consignacion;
        static ConsignacionService consignacionService = new ConsignacionService();
        ExportacionService exportacionService = new ExportacionService();
        Exportacion exportacion;

        public Form1()
        {
            InitializeComponent();
            //Llenar combobox de entidades
            entidadCmb.DataSource = Enum.GetValues(typeof(Entidad));
            entidadCmb.SelectedIndex = -1;
            //llenar combobox de entidades para buscar
            entidadBuscarCmb.DataSource = Enum.GetValues(typeof(Entidad));
            entidadBuscarCmb.SelectedIndex = -1;
            LlenarTabla();
        }
        
        private void registrarBtn_Click(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();
            if (numeroReciboText.Text == "" || valorPagoText.Text == "" || fechaPagoPick.Text == "" || entidadCmb.Text == "")
            {
                respuesta.Mensaje = "Debe llenar todos los campos";
                respuesta.Tipo = TipoMensaje.ADVERTENCIA;
            }
            else
            {
                consignacion = new Consignacion();
                consignacion.NumeroDeRecibo = Convert.ToInt32( numeroReciboText.Text);
                consignacion.EntidadDeServicios = ConvertirEntidad(entidadCmb.Text);
                consignacion.FechaDePago = fechaPagoPick.Value.Date;
                consignacion.ValorPagado = double.Parse(valorPagoText.Text);
                respuesta = consignacionService.Guardar(consignacion);
                LimpiarCampos();
            }
            Mensaje(respuesta);
        }

        private void Mensaje(Respuesta respuesta)
        {
            switch (respuesta.Tipo)
            {
                case TipoMensaje.ADVERTENCIA:
                    MessageBox.Show(respuesta.Mensaje, respuesta.Tipo.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case TipoMensaje.ERROR:
                    MessageBox.Show(respuesta.Mensaje, respuesta.Tipo.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoMensaje.INFORMACION:
                    MessageBox.Show(respuesta.Mensaje, respuesta.Tipo.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
                
        public void LlenarTabla()
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            try
            {
                respuesta = consignacionService.Consultar();
                tablaConsignaciones.DataSource = respuesta.Consignaciones;
                totalRecaudadoText.Text = consignacionService.TotalRecaudado().ToString();
                totalElectricaribeText.Text = consignacionService.TotalizarPorTipo(Entidad.Electricaribe).ToString();
                totalEmduparText.Text = consignacionService.TotalizarPorTipo(Entidad.Emdupar).ToString();
                totalGascaribeTxt.Text = consignacionService.TotalizarPorTipo(Entidad.Gascaribe).ToString();
                Mensaje(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "ERROR ::"+ex;
                respuesta.Tipo = TipoMensaje.ERROR;
                respuesta.Consignaciones = null;
                Mensaje(respuesta);
            }
        }

        public void LimpiarCampos()
        {
            numeroReciboText.Text = "";
            valorPagoText.Text = "";
            entidadCmb.SelectedIndex = -1;
            fechaPagoPick.Value = DateTime.Now.Date;
        }

        private void consultarBtn_Click(object sender, EventArgs e)
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            if (fechaBusquedaPick.Value == null || entidadBuscarCmb.SelectedIndex == -1)
            {
                respuesta.Tipo = TipoMensaje.ERROR;
                respuesta.Mensaje = "Debe seleccionar una entidad y establecer una fecha";
                respuesta.Consignaciones = null;
            }
            else
            {
                string value = entidadBuscarCmb.Text;
                Entidad entidad = ConvertirEntidad(value);
                respuesta = consignacionService.ConsultarPorTipoYFecha(entidad, fechaBusquedaPick.Value.Date);
                tablaConsignaciones.DataSource = respuesta.Consignaciones;
                FiltrarTabla(entidad);
            }
            Mensaje(respuesta);
        }

        public void FiltrarTabla(Entidad entidad)
        {
            string total = consignacionService.TotalizarPorTipoYFecha(entidad, fechaBusquedaPick.Value.Date).ToString();
            totalRecaudadoText.Text = consignacionService.TotalRecaudadoPorEntidadYFecha(entidad,fechaBusquedaPick.Value.Date).ToString();
            switch (entidad)
            {
                case Entidad.Electricaribe:
                    totalGascaribeTxt.Text = "0";
                    totalEmduparText.Text = "0";
                    totalElectricaribeText.Text = total;
                    break;
                case Entidad.Gascaribe:
                    totalGascaribeTxt.Text = total;
                    totalEmduparText.Text = "0";
                    totalElectricaribeText.Text = "0";
                    break;
                case Entidad.Emdupar:
                    totalGascaribeTxt.Text = "0";
                    totalEmduparText.Text = total;
                    totalElectricaribeText.Text = "0";
                    break;
            }
        }

        private void exportarBtn_Click(object sender, EventArgs e)
        { 
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            if (entidadBuscarCmb.SelectedIndex == -1)
            {
                respuesta.Tipo = TipoMensaje.ADVERTENCIA;
                respuesta.Mensaje = "Debe seleccionar una entidad y establecer una fecha";
                respuesta.Consignaciones = null;
                Mensaje(respuesta);
            }
            else
            {
                string msm = $"Esta seguro de exportar consignaciones de  esta entidad {entidadBuscarCmb.Text} ";
                DialogResult result = MessageBox.Show(msm,"EXPORTAR",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Exportar();
                }
            }
        }

        public void Exportar()
        {
            RespuestaDeConsulta respuestaConsulta = new RespuestaDeConsulta();
            try
            {
                Entidad entidad = ConvertirEntidad(entidadBuscarCmb.Text);
                respuestaConsulta = consignacionService.ConsultarPorTipo(entidad);
                if (respuestaConsulta.Consignaciones.Count > 0)
                {
                    Respuesta respuesta = new Respuesta();
                    try
                    {
                        this.exportacion = new Exportacion();
                        this.exportacion.Entidad = ConvertirEntidad(entidadBuscarCmb.Text);
                        this.exportacion.CantidadDePagos = consignacionService.TotalizarPorTipo(exportacion.Entidad);
                        this.exportacion.consignaciones = respuestaConsulta.Consignaciones;
                        this.exportacion.FechaDelReporte = DateTime.Now.Date;
                        this.exportacion.TotalRecaudado = consignacionService.TotalRecaudadoPorEntidad(exportacion.Entidad);
                        respuesta = exportacionService.ExportarConsignacion(exportacion);
                        Mensaje(respuesta);
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje = "ERROR ::"+ex.Message;
                        respuesta.Tipo = TipoMensaje.ERROR;
                        Mensaje(respuesta);
                    }
                }
                else
                {
                    Mensaje(respuestaConsulta);
                }
            }
            catch (Exception ex)
            {
                respuestaConsulta.Mensaje = "ERROR :: "+ex.Message;
                respuestaConsulta.Consignaciones = null;
                respuestaConsulta.Tipo = TipoMensaje.ERROR;
                Mensaje(respuestaConsulta);
            }
        }

        public Entidad ConvertirEntidad(string value)
        {
            return (Entidad)Enum.Parse(typeof(Entidad), value);
        }

        private void cargarBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
