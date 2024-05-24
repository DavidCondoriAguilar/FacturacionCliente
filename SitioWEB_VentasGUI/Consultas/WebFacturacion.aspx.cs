using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyVentas_BL;
using ProyVentas_BE;

namespace SitioWEB_VentasGUI.Consultas
{
    public partial class WebFacturacion : System.Web.UI.Page
    {
        //Creamos instancias
        VendedorBL objVendedorBL = new VendedorBL();
        FacturaBL objFacturaBL = new FacturaBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Cargamos el combo de vendedores
                    cboVendedores.DataSource = objVendedorBL.ListarNombresVendedor();
                    cboVendedores.DataValueField = "Cod_ven";
                    cboVendedores.DataTextField = "ApellNom_ven";
                    cboVendedores.DataBind();
                }
            }
            catch (Exception ex)
            {

                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }

        private void CargarDatos()
        {
            DateTime fecInicio = Convert.ToDateTime(txtFecInicio.Text);
            DateTime fecFin = Convert.ToDateTime(txtFecFin.Text);

            if (fecInicio>fecFin)
            {
                throw new Exception("La fecha de inicio no puede ser mayor que la de fin");
            }

            lblRegistros.Text = "Facturas en el periodo:" +
                    objFacturaBL.ListarFacturasVendedorFechas(cboVendedores.SelectedValue.ToString(),
                                                              fecInicio, fecFin).Count.ToString();

            grvFacturas.DataSource = objFacturaBL.ListarFacturasVendedorFechas(cboVendedores.SelectedValue.ToString(),
                                                                fecInicio, fecFin);
            grvFacturas.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFecInicio.Text.Trim() == String.Empty || txtFecFin.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar las fechas de inicio y fin");
                }
                CargarDatos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}