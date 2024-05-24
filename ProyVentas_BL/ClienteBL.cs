using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyVentas_BE;
using ProyVentas_ADO;

namespace ProyVentas_BL
{
    public class ClienteBL
    {
        ClienteADO objClienteADO = new ClienteADO();

        public ClienteBE ConsultarCliente(String strCodigo)
        {
            return objClienteADO.consultarCliente(strCodigo);
        }

        public Single CalcularDeudaCliente(String strCodigo)
        {
            return objClienteADO.CalcularDeudaCliente(strCodigo);
        }

    }
}
