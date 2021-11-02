using CasoExamen.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;



namespace CasoExamen.Controllers
{
    
    public class AdminController : Controller
    {
        [Authorize]
        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (IsValid(admin))
            {
                FormsAuthentication.SetAuthCookie(admin.Correo, false);
                if(RedirectToAction("Home", "Admin") == RedirectToAction("Home","Admin"))
                {
                    return RedirectToAction("Login", "Admin");
                }

                return RedirectToAction("Home", "Admin");
            }
            return View(admin);
        }

        private bool IsValid(Admin admin)
        {
            return admin.Autenticar();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}