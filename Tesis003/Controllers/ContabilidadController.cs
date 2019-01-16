using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class ContabilidadController : Controller
    {
		// GET: Contabilidad
		public ActionResult IngresoContabilidad()
		{
			return View();
		}

		public ActionResult EgresoContabilidad()
		{
			return View();
		}

		public ActionResult InformeContabilidad()
		{
			return View();
		}

		public ActionResult PagoPersonal()
		{
			return View();
		}
	}
}