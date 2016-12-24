using EmotionPlatzi.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmotionPlatzi.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Home casa = new Home();
            casa.cabecera = "arroz";
            casa.piedepagina = "Frijol pie de pagina";
            return View(casa);
        }
    }
}