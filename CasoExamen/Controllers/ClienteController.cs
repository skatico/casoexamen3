using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoExamen.Negocio;

namespace CasoExamen.Controllers
{
    
    public class ClienteController : Controller
    {

        
        public ActionResult Home()
        {
            
            return View();
        }
        // GET: Cliente
        
        public ActionResult Index()
        {
            ViewBag.clientes = new Cliente().ReadAll();
            return View();
        }
        public ActionResult List()
        {
            ViewBag.clientes = new Cliente().ReadAll();
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            EnviarRubros();
            return View();
        }

        private void EnviarRubros()
        {
            ViewBag.rubros = new Rubro().ReadAll();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Rut,NomEmpresa,NomRepre,ApeRepre,Correo,Direccion,Telefono,RubroId")]Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                cliente.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente c = new Cliente().Find(id);

            if (c == null)
            {
                TempData["mensaje"] = "El Cliente no existe";
                return RedirectToAction("Index");
            }
            EnviarRubros();
            return View(c);
            
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Rut,NomEmpresa,NomRepre,ApeRepre,Correo,Password,Direccion,Telefono,RubroId")]Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarRubros();
                    return View(cliente);
                }
                // TODO: Add update logic here
                cliente.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Cliente().Find(id) == null)
            {
                TempData["mensaje"] = "No existe el Cliente";
                return RedirectToAction("Index");
            }
            if (new Cliente().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "Error al eliminar cliente";
            return RedirectToAction("Index");
            
        }

        // POST: Cliente/Delete/5
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
