using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyVentas_BE
{
    public class VendedorBE
    {
        public String Cod_ven { get; set; }

        public String Nom_ven { get; set; }

        public String Ape_ven { get; set; }

        public String ApellNom_ven { get; set; }

        public Single Sue_ven { get; set; }

        public DateTime Fec_ing { get; set; }

        public Int16 Tip_ven { get; set; }

        public String DNI_ven { get; set; }

        public String Email_ven { get; set; }

        public String Cod_Supervisor { get; set; }

        public String ApellNom_Supervisor { get; set; }

        public DateTime Fec_Registro { get; set; }

        public String Usu_Registro { get; set; }

        public DateTime Fec_Ult_Mod { get; set; }

        public String Usu_Ult_Mod { get; set; }

        public Int16 Est_ven { get; set; }

        public String Estado { get; set; }

    }
}
