using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoExamen.Negocio;

namespace CasoExamen.Controllers
{
    public class AsesoriaController : Controller
    {
        // GET: Asesoria
        public ActionResult Index()
        {
            ViewBag.asesorias = new Asesoria().ReadAll();
            return View();
        }

        // GET: Asesoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asesoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asesoria/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Fecha,Descripcion")]Asesoria asesoria)
        {
            try
            {
                // TODO: Add insert logic here
                asesoria.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(asesoria);
            }
        }

        // GET: Asesoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asesoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asesoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asesoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
