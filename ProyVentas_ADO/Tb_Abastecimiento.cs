//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyVentas_ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Abastecimiento
    {
        public string Cod_prv { get; set; }
        public string Cod_pro { get; set; }
        public float Pre_Aba { get; set; }
    
        public virtual Tb_Producto Tb_Producto { get; set; }
        public virtual Tb_Proveedor Tb_Proveedor { get; set; }
    }
}
