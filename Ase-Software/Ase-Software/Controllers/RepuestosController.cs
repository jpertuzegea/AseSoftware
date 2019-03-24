using Ase_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ase_Software.Controllers
{
    public class RepuestosController : Controller
    {
        // GET: Repuestos
        private SIGECOREntities bd = new SIGECOREntities();

        public ActionResult Index()
        {
            return View(bd.repuesto.ToList());
        }


        [HttpGet]
        public ActionResult RepuestoAdd()
        { 
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RepuestoAdd(repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bd.SP_INS_REPUESTO(repuesto.nombre, repuesto.marca, repuesto.precio_unidad,repuesto.stock);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View(repuesto);
                }

            }
            else
            {
                return View(repuesto);
            }
        }


        //Update
        [HttpGet]
        public ActionResult RepuestoUpdt(int id)
        {
            repuesto repuesto = bd.repuesto.Find(id);
          return View(repuesto);
        }


        //Update
        [HttpPost]
        public ActionResult RepuestoUpdt(repuesto repuesto, int id)
        {
            if (repuesto != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        /* repuesto.repuesto_id = id;
                         bd.Entry(repuesto).State = EntityState.Modified;
                         bd.SaveChanges();
                         */

                        // USANDO PROCEDIMIENTOS 
                        bd.SP_UPDT_REPUESTO(repuesto.repuesto_id, repuesto.nombre, repuesto.marca, repuesto.precio_unidad, repuesto.stock);
                        bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        return View(repuesto);
                    }
                }
                else
                {
                    return View(repuesto);
                }
            }
            return View(repuesto);
        }



    }
}