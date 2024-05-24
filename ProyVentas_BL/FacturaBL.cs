using System;
using System.Collections.Generic;
using ProyVentas_BE;
using ProyVentas_ADO;

namespace ProyVentas_BL
{
    public class FacturaBL
    {
        FacturaADO objFacturaADO = new FacturaADO();

        public List<FacturaBE> ListarFacturasClienteFechas(string strCodigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                // Llamamos al método del ADO para obtener la lista de facturas
                return objFacturaADO.ListarFacturasClienteFechas(strCodigo, fecIni, fecFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en FacturaBL.ListarFacturasClienteFechas: " + ex.Message);
            }
        }

        public List<FacturaBE> ListarFacturasVendedorFechas(string strCodigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                // Llamamos al método del ADO para obtener la lista de facturas
                return objFacturaADO.ListarFacturasVendedorFechas(strCodigo, fecIni, fecFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en FacturaBL.ListarFacturasVendedorFechas: " + ex.Message);
            }
        }
    }
}
