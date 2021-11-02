using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoExamen.Negocio;

namespace CasoExamen.Controllers
{
    public class VisitaController : Controller
    {
        // GET: Visita
        public ActionResult Index()
        {
            ViewBag.visitas = new Visita().ReadAll();
            return View();
        }

        // GET: Visita/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Visita/Create
        public ActionResult Create()
        {
            EnviarProfesionales();
            return View();
        }
        private void EnviarProfesionales()
        {
            ViewBag.profesionales = new Profesional().ReadBox();
        }

        // POST: Visita/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Fecha,Descripcion,IdProf")]Visita visita)
        {
            try
            {
                // TODO: Add insert logic here
                visita.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(visita);
            }
        }

        // GET: Visita/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Visita/Edit/5
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

        // GET: Visita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visita/Delete/5
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
