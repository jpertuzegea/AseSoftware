//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ase_Software.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mecanico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mecanico()
        {
            this.factura = new HashSet<factura>();
            this.servicio = new HashSet<servicio>();
        }
    
        public int mecanico_id { get; set; }
        public string nombre_completo { get; set; }
        public string estado { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicio> servicio { get; set; }
    }
}
