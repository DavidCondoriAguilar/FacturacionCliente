using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregar
using ProyVentas_BE;
namespace ProyVentas_ADO
{
    public class ClienteADO
    {
        public ClienteBE consultarCliente(String strCodigo)
        {
			try
			{
				//Creamos una instancia del modelo
				VentasLeonEntities MisVentas = new VentasLeonEntities();

				//Obtenemos la informacion del cliente ... con LINQ
				Tb_Cliente objCliente = 
					(
						from miCliente in MisVentas.Tb_Cliente
						where miCliente.Cod_cli == strCodigo
						select miCliente
					).FirstOrDefault();

				//Devolvemos los datos en la entidad de negocios
				ClienteBE objClienteBE = new ClienteBE();

				//Evaluamos si el cliente existe

				if (objCliente ==null)
				{
					//Si el cliente no existe se devuelve cadena en blanco
					objClienteBE.Cod_cli = String.Empty;
				}
				else
				{

				objClienteBE.Cod_cli = objCliente.Cod_cli;
				objClienteBE.Raz_soc_cli = objCliente.Raz_soc_cli;
				objClienteBE.Dir_cli = objCliente.Dir_cli;
				objClienteBE.Tel_cli = objCliente.Tel_cli;
				objClienteBE.Ruc_cli = objCliente.Ruc_cli;
				objClienteBE.Departamento = objCliente.Tb_Ubigeo.Departamento;
				objClienteBE.Provincia = objCliente.Tb_Ubigeo.Provincia;
				objClienteBE.Distrito = objCliente.Tb_Ubigeo.Distrito;
				objClienteBE.Est_cli = Convert.ToInt16(objCliente.Est_cli);
				objClienteBE.Deuda = CalcularDeudaCliente(objCliente.Cod_cli);

				}

				return objClienteBE;
            }

			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }

		public Single CalcularDeudaCliente(String strCodigo)
		{
			try
			{
				//Creamos una instancia del modelo...
				VentasLeonEntities MisVentas = new VentasLeonEntities();

                //Definimos variables para la deuda
                Single sngDeuda;

				//obtenemos la cantidad de facturas pendiente del cliente, con expresion Lambda LINQ
				int FacPendientes = MisVentas.Tb_Factura.Where(
					miFactura => miFactura.Est_fac == 1 && miFactura.Cod_cli == strCodigo).Count();
				if (FacPendientes == 0)
				{
					sngDeuda = 0;
				}
				else
                {//Calculamos la deuda con LINQ
                    sngDeuda = Convert.ToSingle
                    (
                        (
                        from miFactura in MisVentas.Tb_Factura
                        join misDetalles in MisVentas.Tb_Detalle_Factura
                            on miFactura.Num_fac equals misDetalles.Num_fac
                        where miFactura.Cod_cli == strCodigo && miFactura.Est_fac == 1
                        select misDetalles.Can_ven * misDetalles.Pre_ven
                        ).Sum()
                    );
                }
                //retornamos la deuda
				return sngDeuda;
            }
			catch (Exception ex)
			{
                throw new Exception(ex.Message);
            }
		}
    }
}
