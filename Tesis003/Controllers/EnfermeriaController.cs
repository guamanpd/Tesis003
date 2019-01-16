using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class EnfermeriaController : Controller
    {
        // GET: Enfermeria
        public ActionResult ListarEnfermeria()
        {
            return View();
        }

		public ActionResult RegistrarSignosVitales()
		{
			return View();
		}
	}
}