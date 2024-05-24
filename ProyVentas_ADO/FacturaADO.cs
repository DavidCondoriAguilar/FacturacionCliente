using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using ProyVentas_BE;

namespace ProyVentas_ADO
{
    public class FacturaADO
    {
        public List<FacturaBE> ListarFacturasClienteFechas(string strCodigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                // Instanciamos el modelo
                VentasLeonEntities MisVentas = new VentasLeonEntities();

                // Creamos la lista de facturas a devolver
                List<FacturaBE> objListasFacturas = new List<FacturaBE>();

                // Obtenemos las facturas del cliente entre las fechas pedidas
                var queryFacturaFechas =
                    (
                        from miFactura in MisVentas.Tb_Factura
                        where miFactura.Cod_cli == strCodigo && miFactura.Fec_fac >= fecIni
                                && miFactura.Fec_fac <= fecFin
                        select miFactura
                    );

                // Recorremos objetos almacenados en la variable query y alimentamos la lista de facturas
                foreach (var resultado in queryFacturaFechas)
                {
                    FacturaBE objFacturaBE = new FacturaBE();

                    objFacturaBE.Num_fac = resultado.Num_fac;
                    objFacturaBE.Fec_fac = resultado.Fec_fac;
                    objFacturaBE.Fec_can = resultado.Fec_can;
                    objFacturaBE.Est_fac = Convert.ToInt16(resultado.Est_fac);

                    if (objFacturaBE.Est_fac == 1)
                    {
                        objFacturaBE.Estado = "Pendiente";
                    }
                    else if (objFacturaBE.Est_fac == 2)
                    {
                        objFacturaBE.Estado = "Cancelada";
                    }
                    else
                    {
                        objFacturaBE.Estado = "Anulada";
                    }
                    objFacturaBE.Cod_ven = resultado.Cod_ven;
                    objFacturaBE.ApellNom_ven = resultado.Tb_Vendedor.Ape_ven + "," +
                                                resultado.Tb_Vendedor.Nom_ven;

                    objFacturaBE.Total = Convert.ToSingle
                        (
                            (
                                from miDetalles in MisVentas.Tb_Detalle_Factura
                                where miDetalles.Num_fac == resultado.Num_fac
                                select miDetalles.Can_ven * miDetalles.Pre_ven
                            ).Sum()
                        );
                    // Agregamos la entidad de negocios a la lista
                    objListasFacturas.Add(objFacturaBE);
                }

                return objListasFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<FacturaBE> ListarFacturasVendedorFechas(string strCodigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                // Instanciamos el modelo
                VentasLeonEntities MisVentas = new VentasLeonEntities();

                // Creamos la lista de facturas a devolver
                List<FacturaBE> objListaFacturas = new List<FacturaBE>();

                // Obtenemos las facturas del vendedor entre las fechas consultadas por medio del storeProcedure
                var query = MisVentas.usp_ListarFacturasVendedorFechas(strCodigo, fecIni, fecFin);

                // Recorremos el resultado en el SP y elaboramos la lista
                foreach (var result in query)
                {
                    FacturaBE objFacturaBE = new FacturaBE();

                    objFacturaBE.Num_fac = result.num_fac;
                    objFacturaBE.Fec_fac = result.fec_fac;
                    objFacturaBE.Fec_can = result.fec_can;
                    objFacturaBE.Estado = result.estado;
                    objFacturaBE.Cod_cli = result.Cod_cli;
                    objFacturaBE.Raz_soc_cli = result.Raz_soc_cli;
                    objFacturaBE.Total = Convert.ToSingle(result.total);

                    objListaFacturas.Add(objFacturaBE);
                }

                return objListaFacturas;
            }

            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
