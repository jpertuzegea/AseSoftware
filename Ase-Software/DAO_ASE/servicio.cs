//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO_ASE
{
    using System;
    using System.Collections.Generic;
    
    public partial class servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servicio()
        {
            this.repuesto_servicio = new HashSet<repuesto_servicio>();
        }
    
        public int servicio_id { get; set; }
        public Nullable<int> vehiculo_id { get; set; }
        public string descripcion_danno { get; set; }
        public Nullable<int> mecanico_id { get; set; }
        public Nullable<int> presupuesto_arreglo { get; set; }
        public Nullable<int> estimacion_tiempo_hrs { get; set; }
        public Nullable<int> estimacion_precio { get; set; }
        public Nullable<int> precio_mano_obra { get; set; }
        public byte[] foto { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public Nullable<System.DateTime> fecha_salida { get; set; }
    
        public virtual mecanico mecanico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<repuesto_servicio> repuesto_servicio { get; set; }
        public virtual vehiculo vehiculo { get; set; }
    }
}
