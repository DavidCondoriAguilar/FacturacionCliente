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
    
    public partial class Tb_Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Categoria()
        {
            this.Tb_Producto = new HashSet<Tb_Producto>();
        }
    
        public int Id_Cat { get; set; }
        public string Des_Cat { get; set; }
        public byte[] Foto_Cat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Producto> Tb_Producto { get; set; }
    }
}
