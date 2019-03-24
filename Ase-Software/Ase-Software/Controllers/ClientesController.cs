using Ase_Software.Models;
using Ase_Software.Varios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ase_Software.Controllers
{
    public class ClientesController : Controller
    {
        private SIGECOREntities bd = new SIGECOREntities();


        // GET: Clientes
        public ActionResult Index()
        {
            return View(bd.cliente.ToList());
        }


        [HttpGet]
        public ActionResult ClientesAdd()
        {
            ViewBag.sexo = Selects.list_sexo();
            ViewBag.estado = Selects.list_estado();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientesAdd(cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bd.SP_INS_CLIENTE(cliente.num_identificacion, cliente.nombre_completo, cliente.sexo, cliente.telefono, cliente.direccion, cliente.ciudad, cliente.email, cliente.estado);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.estado = Selects.list_estado();
                    ViewBag.sexo = Selects.list_sexo();
                    return View(cliente);
                }

            }
            else
            {
                ViewBag.estado = Selects.list_estado();
                ViewBag.sexo = Selects.list_sexo();
                return View(cliente);
            }
        }

        //Update
        [HttpGet]
        public ActionResult ClientesUpdt(int id)
        {
            cliente cliente = bd.cliente.Find(id);

            ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", cliente.estado);
            ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", cliente.sexo);
            return View(cliente);
        }

        //Update
        [HttpPost]
        public ActionResult ClientesUpdt(cliente cliente, int id)
        {
            if (cliente != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        /* cliente.cliente_id = id;
                         bd.Entry(cliente).State = EntityState.Modified;
                         bd.SaveChanges();
                         */

                        // USANDO PROCEDIMIENTOS 
                        bd.SP_UPDT_CLIENTE(cliente.cliente_id, cliente.num_identificacion, cliente.nombre_completo, cliente.sexo, cliente.telefono, cliente.direccion, cliente.ciudad, cliente.email, cliente.estado);
                        bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", cliente.estado);
                        ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", cliente.sexo);
                        return View(cliente);
                    }
                }
                else
                {
                    ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", cliente.estado);
                    ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", cliente.sexo);
                    return View(cliente);
                }
            }
            ViewBag.estado = new SelectList(Selects.list_estado(), "Value", "Text", cliente.estado);
            ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", cliente.sexo);
            return View(cliente);
        }



      



    }
}