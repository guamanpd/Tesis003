using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        public ActionResult Ingreso()
        {
            return View();
        }

		public ActionResult Presentacion()
		{
			return View();
		}
	}
}