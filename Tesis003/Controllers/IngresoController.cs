using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesis003.Models;

namespace Tesis003.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        [HttpGet]
        public ActionResult Ingreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingreso(UsuarioModel usuario)
        {
            return View();
        }

		public ActionResult Presentacion()
		{
			return View();
		}
	}
}