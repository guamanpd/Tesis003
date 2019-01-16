using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult IngresarCita()
        {
            return View();
        }

		public ActionResult ListarCita()
		{
			return View();
		}
	}
}