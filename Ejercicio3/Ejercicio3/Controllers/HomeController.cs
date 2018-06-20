using Ejercicio3.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        private MaterialesRepositorio _materialesRepositorio;

        public HomeController()
        {
            _materialesRepositorio = new MaterialesRepositorio();
        }
        public ActionResult Index()
        {
            var model = _materialesRepositorio.GetMaterial();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
            return View();
        }
    }
}