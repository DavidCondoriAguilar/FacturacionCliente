﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVentas_ADO;
using ProyVentas_BE;

namespace ProyVentas_BL
{
    public class VendedorBL
    {
        VendedorADO objVendedorADO = new VendedorADO();
        public List<VendedorBE> ListarNombresVendedor()
        {
            return objVendedorADO.ListarNombresVendedor();
        }
    }
}
