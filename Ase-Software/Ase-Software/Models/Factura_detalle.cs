using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ase_Software.Models
{
    public class Factura_detalle
    {
        public string nombre_mecanico { get; set; }
        public string nombre_cliente { get; set; }
        public List<repuesto> repuestos_del_servicio { get; set; }
        public int? valor_mano_obra { get; set; }
        public double? valor_total { get; set; }
        public double? iva { get; set; }
        public DateTime fecha_emision { get; set; }
    }
}