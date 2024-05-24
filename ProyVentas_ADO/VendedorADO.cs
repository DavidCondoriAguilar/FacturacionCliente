using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVentas_BE;


namespace ProyVentas_ADO
{
    public class VendedorADO
    {
        public List<VendedorBE> ListarNombresVendedor()
        {
			try
			{
				//Creamos una instancia del modelo(DbContext)
				VentasLeonEntities MisVentas = new VentasLeonEntities();

				//Creamos la lista de vendedores
				List<VendedorBE> objLista = new List<VendedorBE>();

				//Obetemos el resultado SP usp_listarnombredvendedor
				var query = MisVentas.usp_ListarNombresVendedor();

				//Recoremos el resultado creando una lista
				foreach (var resultado in query)
				{
					VendedorBE objVendedorBE = new VendedorBE();
					objVendedorBE.Cod_ven = resultado.COD_VEN;
					objVendedorBE.ApellNom_ven = resultado.NOMBRES;

					objLista.Add(objVendedorBE);
				}
				return objLista;
            }
			catch (EntityException ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
