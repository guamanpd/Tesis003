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
		public ActionResult Diagnostico()
		{
			return View();
		}
		public ActionResult Odontograma()
		{
			return View();
		}
		public ActionResult ListarConsultasPrevias()
		{
			return View();
		}
		public ActionResult MostrarConsultaPrevia()
		{
			return View();
		}
		public ActionResult ConsultaSubsecuente()
		{
			return View();
		}

		public ActionResult ListaSignosVitales()
		{
			return View();
		}

		public ActionResult MostrarIndiceMasaCorporal()
		{
			return View();
		}

		public ActionResult MostrarPeso()
		{
			return View();
		}

		public ActionResult MostrarTalla()
		{
			return View();
		}

		public ActionResult MostrarCertificadoMedico()
		{
			return View();
		}
	}
}