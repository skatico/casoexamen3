using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CasoExamen.Negocio;

namespace CasoExamen.Controllers
{
    public class ProfesionalController : Controller
    {
        
        public ActionResult Home()
        {

            return View();
        }
        // GET: Profesional
        public ActionResult Index()
        {
            ViewBag.profesionales = new Profesional().ReadAll();
            return View();
        }

        // GET: Profesional/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profesional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesional/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Rut,Correo,Numero")]Profesional profesional)
        {
            try
            {
                // TODO: Add insert logic here
                profesional.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(profesional);
            }
        }

        // GET: Profesional/Edit/5
        public ActionResult Edit(int id)
        {
            Profesional p = new Profesional().Find(id);

            if (p == null)
            {
                TempData["mensaje"] = "El Profesional no existe";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // POST: Profesional/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Rut,Correo,Password,Numero")]Profesional profesional)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(profesional);
                }
                profesional.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(profesional);
            }
        }

        // GET: Profesional/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Profesional().Find(id) == null)
            {
                TempData["mensaje"] = "No existe el Profesional";
                return RedirectToAction("Index");
            }
            if (new Profesional().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "Error al eliminar Profesional";
            return RedirectToAction("Index");
           
        }

        // POST: Profesional/Delete/5
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
