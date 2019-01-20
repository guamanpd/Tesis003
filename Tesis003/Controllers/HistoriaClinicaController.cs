using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesis003.Controllers
{
    public class HistoriaClinicaController : Controller
    {
        // GET: HistoriaClinica
        public ActionResult DatosPersonales()
        {
            return View();
        }
		public ActionResult Antecedentes()
		{
			return View();
		}
		public ActionResult Consulta()
		{
			return View();
		}
	}
}