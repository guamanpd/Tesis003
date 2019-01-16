using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult IngresarPersonal()
        {
            return View();
        }

		public ActionResult ListarPersonal()
		{
			return View();
		}

		public ActionResult ActualizarPersonal()
		{
			return View();
		}
	}
}