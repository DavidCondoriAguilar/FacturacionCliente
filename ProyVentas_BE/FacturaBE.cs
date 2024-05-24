using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyVentas_BE
{
    public class FacturaBE
    {        
        public String Num_fac { get; set; }
        public DateTime  Fec_fac { get; set; }
        public DateTime? Fec_can { get; set; }
        public String  Cod_cli { get; set; }
        public String Raz_soc_cli { get; set; }
        public Single Total { get; set; }
        public Int16 Est_fac { get; set; }
        public String Estado { get; set; }
        public String Cod_ven { get; set; }        
        public String ApellNom_ven { get; set; }

        public static decimal Sum(Func<object, decimal> value)
        {
            throw new NotImplementedException();
        }
    }

}

