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
    
    public partial class factura
    {
        public int factura_id { get; set; }
        public Nullable<int> mecanico_id { get; set; }
        public Nullable<int> cliente_id { get; set; }
        public int repuesto_servicio_id { get; set; }
        public Nullable<int> valor_total { get; set; }
        public Nullable<int> iva { get; set; }
        public Nullable<System.DateTime> fecha_emision { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual mecanico mecanico { get; set; }
        public virtual repuesto_servicio repuesto_servicio { get; set; }
    }
}
