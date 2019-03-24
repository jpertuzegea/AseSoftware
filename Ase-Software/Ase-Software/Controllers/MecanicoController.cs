using Ase_Software.Models;
using Ase_Software.Varios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ase_Software.Controllers
{
    public class MecanicoController : Controller
    {
        private SIGECOREntities bd = new SIGECOREntities();

        // GET: Mecanios
        public ActionResult Index()
        {
            ViewBag.sexo = Selects.list_sexo();
            ViewBag.estado_mec = Selects.list_estado_mec();

            return View(bd.mecanico.ToList());
        }


        [HttpGet]
        public ActionResult MecanicoAdd()
        {
            ViewBag.sexo = Selects.list_sexo();
            ViewBag.estado_mec = Selects.list_estado_mec();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MecanicoAdd(mecanico mecanico)
        {
            if (ModelState.IsValid)
            {
                try
                {  
                    bd.SP_INS_MECANICO(
                        mecanico.nombre_completo,
                        mecanico.sexo,
                        mecanico.estado,
                        mecanico.telefono,
                        mecanico.direccion,
                        mecanico.email                        );
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.estado_mec = Selects.list_estado_mec();
                    ViewBag.sexo = Selects.list_sexo();
                    return View(mecanico);
                }

            }
            else
            {
                ViewBag.estado_mec = Selects.list_estado_mec();
                ViewBag.sexo = Selects.list_sexo();
                return View(mecanico);
            }
        }


        //Update
        [HttpGet]
        public ActionResult MecanicoUpdt(int id)
        {
            mecanico mecanico = bd.mecanico.Find(id);

            ViewBag.estado_mec = new SelectList(Selects.list_estado_mec(), "Value", "Text", mecanico.estado);
            ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", mecanico.sexo);
            return View(mecanico);
        }

        //Update
        [HttpPost]
        public ActionResult MecanicoUpdt(mecanico mecanico, int id)
        {

            if (mecanico != null)
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        /* mecanico.mecanico_id = id;
                         bd.Entry(mecanico).State = EntityState.Modified;
                         bd.SaveChanges();
                         */

                        // USANDO PROCEDIMIENTOS 
                        bd.SP_UPDT_MECANICO(
                            mecanico.mecanico_id,
                        mecanico.nombre_completo,
                        mecanico.sexo,
                        mecanico.estado,
                        mecanico.telefono,
                        mecanico.direccion,
                        mecanico.email);
                        bd.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        ViewBag.estado_mec = new SelectList(Selects.list_estado_mec(), "Value", "Text", mecanico.estado);
                        ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", mecanico.sexo);
                        return View(mecanico);
                    }
                }
                else
                {
                    ViewBag.estado_mec = new SelectList(Selects.list_estado_mec(), "Value", "Text", mecanico.estado);
                    ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", mecanico.sexo);
                    return View(mecanico);
                }
            }
            ViewBag.estado_mec = new SelectList(Selects.list_estado_mec(), "Value", "Text", mecanico.estado);
            ViewBag.sexo = new SelectList(Selects.list_sexo(), "Value", "Text", mecanico.sexo);
            return View(mecanico);
        }



    }



}

