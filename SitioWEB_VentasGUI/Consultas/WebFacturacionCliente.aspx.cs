using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using ProyVentas_BE;
using ProyVentas_BL;

namespace SitioWEB_VentasGUI.Consultas
{
    public partial class WebFacturacionCliente : System.Web.UI.Page
    {
        ClienteBE objClienteBE = new ClienteBE();
        ClienteBL objClienteBL = new ClienteBL();
        FacturaBL objFacturaBL = new FacturaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnDescargar);

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                btnConsultar.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                objClienteBE = objClienteBL.ConsultarCliente(txtCod.Text.Trim());

                if (string.IsNullOrEmpty(objClienteBE.Cod_cli))
                {
                    LimpiarDatosCliente();
                    throw new Exception("Cliente no encontrado.");
                }

                MostrarDatosCliente(objClienteBE);
                btnConsultar.Enabled = true;
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                grvFacturas.DataSource = objFacturaBL.ListarFacturasClienteFechas(txtCod.Text.Trim(),
                                                             Convert.ToDateTime(txtFecIni.Text.Trim()),
                                                             Convert.ToDateTime(txtFecFin.Text.Trim()));
                grvFacturas.DataBind();

                lblRegistros.Text = "Cantidad de facturas: " + grvFacturas.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Error al consultar las facturas: " + ex.Message);
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaArchivo = Server.MapPath("/") + @"Documentos\ListaFacturaCliente.xlsx";


                List<FacturaBE> objListFacturas = objFacturaBL.ListarFacturasClienteFechas(txtCod.Text.Trim(),
                                                    Convert.ToDateTime(txtFecIni.Text.Trim()),
                                                    Convert.ToDateTime(txtFecFin.Text.Trim()));
                int intRegistros = objListFacturas.Count;

                if (intRegistros == 0)
                {
                    MostrarMensajeError("No hay facturas registradas.");
                    return;
                }

                int fila1 = 5;
                using (var pck = new ExcelPackage(new FileInfo(rutaArchivo)))
                {
                    string fileName = "ListadoFacturaCliente_" + DateTime.Today.ToShortDateString();
                    ExcelWorksheet ws = pck.Workbook.Worksheets["Hoja1"];

                    ws.Cells[2, 4].Value = txtRazSoc.Text;
                    ws.Cells[2, 4].Value = txtFecIni.Text + " y " + txtFecFin.Text;

                    foreach (FacturaBE mifactura in objListFacturas)
                    {
                        ws.Cells[fila1, 1].Value = mifactura.Num_fac;

                        DateTime fecfac = Convert.ToDateTime(mifactura.Fec_fac);
                        ws.Cells[fila1, 2].Value = fecfac.ToShortDateString();
                        ws.Cells[fila1, 3].Value = mifactura.Fec_can?.ToShortDateString() ?? "--";

                        float total = Convert.ToSingle(mifactura.Total);
                        ws.Cells[fila1, 4].Value = total.ToString("#,###,##0.00");
                        ws.Cells[fila1, 5].Value = mifactura.ApellNom_ven;
                        ws.Cells[fila1, 6].Value = mifactura.Estado;
                        fila1++;
                    }

                    ws.Cells[fila1, 1].Value = "Total ingresos: " + intRegistros;

                    for (int col = 1; col <= 6; col++)
                    {
                        ws.Column(col).Width = col == 1 ? 20 : col == 2 || col == 3 ? 30 : 25;
                    }

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xlsx");
                    using (var memoryStream = new MemoryStream())
                    {
                        pck.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private void LimpiarDatosCliente()
        {
            txtRazSoc.Text = string.Empty;
            txtDir.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtRUC.Text = string.Empty;
            txtUbicacion.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtDeuda.Text = string.Empty;
            lblRegistros.Text = string.Empty;
            grvFacturas.DataSource = null;
            grvFacturas.DataBind();
        }

        private void MostrarDatosCliente(ClienteBE cliente)
        {
            txtRazSoc.Text = cliente.Raz_soc_cli;
            txtDir.Text = cliente.Dir_cli;
            txtTel.Text = cliente.Tel_cli;
            txtRUC.Text = cliente.Ruc_cli;
            txtUbicacion.Text = $"{cliente.Departamento}.{cliente.Provincia}.{cliente.Distrito}";
            txtEstado.Text = cliente.Est_cli == 1 ? "Activo" : "Inactivo";
            txtDeuda.Text = cliente.Deuda.ToString("###,##0.00");
        }

        private void MostrarMensajeError(string mensaje)
        {
            lblMensajePopup.Text = "Error: " + mensaje;
            PopMensaje.Show();
        }
    }
}
