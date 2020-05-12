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
        public static List<Consignacion> consignaciones = new List<Consignacion>();
        static Consignacion consignacion;
        static ConsignacionService consignacionService = new ConsignacionService();

        public Form1()
        {
            InitializeComponent();
            //Llenar combobox de entidades
            entidadCmb.DataSource = Enum.GetValues(typeof(Entidad));
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
                consignacion.EntidadDeServicios = (Entidad)Enum.Parse(typeof(Entidad), entidadCmb.Text);
                consignacion.FechaDePago = fechaPagoPick.Value.Date;
                consignacion.ValorPagado = double.Parse(valorPagoText.Text);
                respuesta = consignacionService.Guardar(consignacion);
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

        private void entidadBuscarCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void Consultar()
        {
            if (entidadBuscarCmb.Text != "" && fechaPagoPick.Value.Date != null)
            {
                string value = entidadBuscarCmb.Text;
                FiltrarTabla((Entidad)Enum.Parse(typeof(Entidad), value));
            }
        }

        public void FiltrarTabla(Entidad entidad)
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            respuesta = consignacionService.ConsultarPorTipo(entidad);
            tablaConsignaciones.DataSource = respuesta.Consignaciones;
            string total = consignacionService.Totalizar(entidad).ToString();
            totalRecaudadoText.Text = consignacionService.TotalRecaudadoPorEntidad(entidad).ToString();
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

        public void LlenarTabla()
        {
            RespuestaDeConsulta respuesta = new RespuestaDeConsulta();
            respuesta = consignacionService.Consultar();
            tablaConsignaciones.DataSource = respuesta.Consignaciones;
            totalRecaudadoText.Text = consignacionService.TotalRecaudado().ToString();
            totalElectricaribeText.Text = consignacionService.Totalizar(Entidad.Electricaribe).ToString();
            totalEmduparText.Text = consignacionService.Totalizar(Entidad.Emdupar).ToString();
            totalGascaribeTxt.Text = consignacionService.Totalizar(Entidad.Gascaribe).ToString();
        }

        public void LimpiarCampos()
        {
            numeroReciboText.Text = "";
            valorPagoText.Text = "";
            entidadCmb.SelectedIndex = -1;
            fechaPagoPick.Value = DateTime.Now.Date;
        }


    }
}
