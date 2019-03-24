using Ase_Software.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ase_Software.Varios;
using System.IO;

namespace Ase_Software.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        private SIGECOREntities bd = new SIGECOREntities();

        public ActionResult Index()
        {
            return View(bd.servicio.Include(v => v.vehiculo).Include(m => m.mecanico).ToList());
        }


        [HttpGet]
        public ActionResult ServicioAdd()
        {
            List<SelectListItem> lista_Vehi = Selects.Armar_Select_Vehiculos();
            ViewBag.vehiculo = lista_Vehi;
            List<SelectListItem> lista_Meca = Selects.Armar_Select_Mecanicos();
            ViewBag.mecanico = lista_Meca;
            ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ServicioAdd(servicio servicio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                try
                {

                    byte[] imagenData = null;
                    using (var foto_vehiculo = new BinaryReader(file.InputStream))
                    {
                        imagenData = foto_vehiculo.ReadBytes(file.ContentLength);

                    }
                    servicio.foto = imagenData;


                    bd.SP_INS_SERVICIO(
                        servicio.vehiculo_id,
                        servicio.descripcion_danno,
                        servicio.mecanico_id,
                        servicio.presupuesto_arreglo,
                        servicio.estimacion_tiempo_hrs,
                        servicio.estimacion_precio,
                        servicio.precio_mano_obra,
                        servicio.foto,
                        servicio.fecha_ingreso,
                        servicio.fecha_salida,
                        servicio.estado
                        );
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    List<SelectListItem> lista_Vehi = Selects.Armar_Select_Vehiculos();
                    ViewBag.vehiculo = lista_Vehi;
                    List<SelectListItem> lista_Meca = Selects.Armar_Select_Mecanicos();
                    ViewBag.mecanico = lista_Meca;
                    ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text");

                    return View(servicio);
                }

            }
            else
            {
                List<SelectListItem> lista_Vehi = Selects.Armar_Select_Vehiculos();
                ViewBag.vehiculo = lista_Vehi;
                List<SelectListItem> lista_Meca = Selects.Armar_Select_Mecanicos();
                ViewBag.mecanico = lista_Meca;
                ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text");

                return View(servicio);
            }
        }




        //Update
        [HttpGet]
        public ActionResult ServicioUpdt(int id)
        {
            servicio servicio = bd.servicio.Find(id);
            List<SelectListItem> lista_Vehi = Selects.Armar_Select_Vehiculos();
            ViewBag.Vehiculo = new SelectList(lista_Vehi, "Value", "Text", servicio.vehiculo_id);
            List<SelectListItem> lista_Meca = Selects.Armar_Select_Mecanicos();
            ViewBag.Mecanico = new SelectList(lista_Meca, "Value", "Text", servicio.mecanico_id);
            List<SelectListItem> lista_esta = Selects.list_estado();

            ViewBag.estado = new SelectList(lista_esta, "Value", "Text", servicio.estado);
            return View(servicio);
        }

        //Update
        [HttpPost]
        public ActionResult ServicioUpdt(servicio servicio, int id, HttpPostedFileBase file)
        {
            List<SelectListItem> lista_Vehi = Selects.Armar_Select_Vehiculos();
            List<SelectListItem> lista_Meca = Selects.Armar_Select_Mecanicos();
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                if (servicio != null)
                {

                    try
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            byte[] imagenData = null;
                            using (var foto_vehiculo = new BinaryReader(file.InputStream))
                            {
                                imagenData = foto_vehiculo.ReadBytes(file.ContentLength);
                            }
                            servicio.foto = imagenData;
                        }

                        /* servicio.servicio = id;
                         bd.Entry(servicio).State = EntityState.Modified;
                         bd.SaveChanges();
                         */

                        // USANDO PROCEDIMIENTOS 
                        bd.SP_UPDT_SERVICIO(
                        servicio.vehiculo_id,
                        servicio.descripcion_danno,
                        servicio.mecanico_id,
                        servicio.presupuesto_arreglo,
                        servicio.estimacion_tiempo_hrs,
                        servicio.estimacion_precio,
                        servicio.precio_mano_obra,
                        servicio.foto,
                        servicio.fecha_ingreso,
                        servicio.fecha_salida,
                        servicio.estado);

                        bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {

                        ViewBag.Vehiculo = new SelectList(lista_Vehi, "Value", "Text", servicio.vehiculo_id); ;
                        ViewBag.Mecanico = new SelectList(lista_Meca, "Value", "Text", servicio.mecanico_id); ;
                        ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", servicio.estado);
                        return View(servicio);
                    }

                }
            }
            else
            {
                ViewBag.Vehiculo = new SelectList(lista_Vehi, "Value", "Text", servicio.vehiculo_id); ;
                ViewBag.Mecanico = new SelectList(lista_Meca, "Value", "Text", servicio.mecanico_id); ;
                ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", servicio.estado);
                return View(servicio);
            }
            ViewBag.Vehiculo = new SelectList(lista_Vehi, "Value", "Text", servicio.vehiculo_id); ;
            ViewBag.Mecanico = new SelectList(lista_Meca, "Value", "Text", servicio.mecanico_id); ;
            ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", servicio.estado);
            return View(servicio);
        }

        public ActionResult convertirImagen(int servicio_id)
        {
            servicio servicio = bd.servicio.Find(servicio_id);
            return File(servicio.foto, "image/jpg");

        }



        [HttpGet]
        public ActionResult Repu_servicio(int id)
        {
            List<SelectListItem> lista_repu = Selects.Armar_Select_Repuestos();
            ViewBag.repuestos = lista_repu;
            ViewBag.servicio_id = id;
            return View();
        }

        //Update
        [HttpPost]
        public ActionResult Repu_servicio(repuesto_servicio repuesto_servicio, int id)
        {
            try
            {
                bd.SP_INS_REPUESTO_SERVICIO(repuesto_servicio.repuesto_id, id);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }



        [HttpGet]
        public ActionResult factura_servicio(int id)
        {
            int? valor_total = 0;
            servicio servicio = bd.servicio.Find(id);

            Factura_detalle Factura_detal = new Factura_detalle();

            Factura_detal.fecha_emision = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"));
            vehiculo vehiculo = bd.vehiculo.Find(servicio.vehiculo_id);
            cliente cliente = bd.cliente.Find(vehiculo.propietario_id);
            Factura_detal.nombre_cliente = cliente.nombre_completo;
            mecanico meca = bd.mecanico.Find(servicio.mecanico_id);
            Factura_detal.nombre_mecanico = meca.nombre_completo;
            Factura_detal.valor_mano_obra = servicio.precio_mano_obra;
            //   List<repuesto_servicio> lista = bd.repuesto_servicio.Where(c => c.servicio_id == id).ToList();
            List<repuesto_servicio> lista = bd.repuesto_servicio.Where(c => c.servicio_id == id).ToList();


            List<repuesto> list_repue = new List<repuesto>();
            foreach (var item in lista)
            {
                repuesto repuesto = bd.repuesto.Find(item.repuesto_id);
                list_repue.Add(repuesto);
                valor_total = valor_total + repuesto.precio_unidad;
            }
            Factura_detal.repuestos_del_servicio = list_repue;
            valor_total = valor_total + Factura_detal.valor_mano_obra;

            Factura_detal.iva = (valor_total * 0.019);

            Factura_detal.valor_total = valor_total + Factura_detal.iva;

            return View(Factura_detal);
        }



    }
}