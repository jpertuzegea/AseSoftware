using Ase_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ase_Software.Varios
{
    public static class Selects
    {
        private static CarEntities1 BD = new CarEntities1();

        private static List<SelectListItem> estado = null;
        private static List<SelectListItem> sexo = null;
        private static List<SelectListItem> estado_mec = null;


        public static List<SelectListItem> list_sexo()
        {

            if (sexo == null)
            {
                sexo = new List<SelectListItem>();
                sexo.Add(new SelectListItem() { Text = "Hombre", Value = "Hombre" });
                sexo.Add(new SelectListItem() { Text = "Mujer", Value = "Mujer" });
                return sexo;
            }
            else
            {
                return sexo;
            }
        }
        public static List<SelectListItem> list_estado()
        {
            if (estado == null)
            {
                estado = new List<SelectListItem>();
                estado.Add(new SelectListItem() { Text = "Activo", Value = "Activo" });
                estado.Add(new SelectListItem() { Text = "Inactivo", Value = "Inactivo" });
                return estado;
            }
            else
            {
                return estado;
            }
        }
        public static List<SelectListItem> list_estado_mec()
        {

            if (estado_mec == null)
            {
                estado_mec = new List<SelectListItem>();
                estado_mec.Add(new SelectListItem() { Text = "Libre", Value = "Libre" });
                estado_mec.Add(new SelectListItem() { Text = "Ocupado", Value = "Ocupado" });
                return estado;
            }
            else
            {
                return estado_mec;
            }
        }

        public static List<SelectListItem> Armar_Select_Clientes()
        {
            List<SelectListItem> result = new List<SelectListItem>();// se debe importar la dll que esta en el proyecto vista
            var list = BD.cliente.ToList();

            foreach (var item in list)
            {
                var nombre = item.nombre_completo;
                var valor = item.cliente_id;
                result.Add(new SelectListItem() { Text = nombre, Value = valor.ToString() });
            }
            return result;
        }
        public static List<SelectListItem> Armar_Select_Vehiculos()
        {
            List<SelectListItem> result = new List<SelectListItem>();// se debe importar la dll que esta en el proyecto vista
            var list = BD.vehiculo.ToList();

            foreach (var item in list)
            {
                var nombre = item.modelo;
                var valor = item.vehiculo_id;
                result.Add(new SelectListItem() { Text = nombre, Value = valor.ToString() });
            }
            return result;
        }
        public static List<SelectListItem> Armar_Select_Mecanicos()
        {
            List<SelectListItem> result = new List<SelectListItem>();// se debe importar la dll que esta en el proyecto vista
            var list = BD.mecanico.ToList();

            foreach (var item in list)
            {
                var nombre = item.nombre_completo;
                var valor = item.mecanico_id;
                result.Add(new SelectListItem() { Text = nombre, Value = valor.ToString() });
            }
            return result;
        }
        public static List<SelectListItem> Armar_Select_Repuestos()
        {
            List<SelectListItem> result = new List<SelectListItem>();// se debe importar la dll que esta en el proyecto vista
            var list = BD.repuesto.ToList();

            foreach (var item in list)
            {
                var nombre = item.nombre;
                var valor = item.repuesto_id;
                result.Add(new SelectListItem() { Text = nombre, Value = valor.ToString() });
            }
            return result;
        }

        
    }
}