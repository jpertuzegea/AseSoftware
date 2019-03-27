using Ase_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Ase_Software.Varios;

namespace Ase_Software.Controllers
{
    public class VehiculosController : Controller
    {

        private CarEntities1 bd = new CarEntities1();
        
        // GET: Vehiculos
        public ActionResult Index()
        {
            return View(bd.vehiculo.Include(u => u.cliente).ToList());
        }

        [HttpGet]
        public ActionResult VehiculoAdd()
        {
            ClientesController ClientesController = new ClientesController();
            List<SelectListItem> lista = Selects.Armar_Select_Clientes();
            ViewBag.propietario = lista;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VehiculoAdd(vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bd.SP_INS_VEHICULO(vehiculo.marca, vehiculo.modelo, vehiculo.color, vehiculo.anno.ToString(), vehiculo.propietario_id);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    List<SelectListItem> lista = Selects.Armar_Select_Clientes();
                    ViewBag.propietario = lista;
                    return View(vehiculo);
                }

            }
            else
            {
                List<SelectListItem> lista = Selects.Armar_Select_Clientes();
                ViewBag.propietario = lista;
                return View(vehiculo);
            }
        }


        //Update
        [HttpGet]
        public ActionResult VehiculoUpdt(int id)
        {
            vehiculo vehiculo = bd.vehiculo.Find(id);
            List<SelectListItem> lista = Selects.Armar_Select_Clientes();
            ViewBag.propietario = lista;
            return View(vehiculo);
        }

        //Update
        [HttpPost]
        public ActionResult VehiculoUpdt(vehiculo vehiculo, int id)
        {
            ClientesController ClientesController = new ClientesController();
            List<SelectListItem> lis = Selects.Armar_Select_Clientes();

            if (vehiculo != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        /* vehiculo.vehiculo_id = id;
                         bd.Entry(vehiculo).State = EntityState.Modified;
                         bd.SaveChanges();
                         */

                        // USANDO PROCEDIMIENTOS 
                        bd.SP_UPDT_VEHICULO(vehiculo.vehiculo_id, vehiculo.marca, vehiculo.modelo, vehiculo.color, vehiculo.anno.ToString(), vehiculo.propietario_id);
                        bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {

                        ViewBag.propietario = new SelectList(lis, "Value", "Text", vehiculo.propietario_id); ;
                        return View(vehiculo);
                    }
                }
                else
                {
                    ViewBag.propietario = new SelectList(lis, "Value", "Text", vehiculo.propietario_id); ;
                    return View(vehiculo);
                }
            }
            ViewBag.propietario = new SelectList(lis, "Value", "Text", vehiculo.propietario_id); ;
            return View(vehiculo);
        }


    }
}