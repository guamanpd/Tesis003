using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesis003.BaseDatos;
using Tesis003.Models;

namespace Tesis003.Controllers
{
    public class PacienteController : Controller
    {
        InformacionConsulta informacionBD = new InformacionConsulta();
        PacienteConsulta pacienteBD = new PacienteConsulta();
        // GET: Paciente
        [HttpGet]
        public ActionResult IngresarPaciente()
        {
            ViewData["numHistoriaClinica"] = informacionBD.obtenerSiguienteNumeroHistoriaClinica();
            ViewData["generos"] = informacionBD.obtenerInformacionParametro("genero");
            ViewData["estados"] = informacionBD.obtenerInformacionParametro("estado civil");
            ViewData["tipos"] = informacionBD.obtenerInformacionParametro("tipo sangre");
            ViewData["etnias"] = informacionBD.obtenerInformacionParametro("etnia");
            return View();
        }

        [HttpPost]
        public ActionResult IngresarPaciente(PacienteModel pacienteParametro)
        {
            pacienteBD.ingresarPaciente(pacienteParametro);

            ViewData["numHistoriaClinica"] = informacionBD.obtenerSiguienteNumeroHistoriaClinica();
            ViewData["generos"] = informacionBD.obtenerInformacionParametro("genero");
            ViewData["estados"] = informacionBD.obtenerInformacionParametro("estado civil");
            ViewData["tipos"] = informacionBD.obtenerInformacionParametro("tipo sangre");
            ViewData["etnias"] = informacionBD.obtenerInformacionParametro("etnia");
            return View();
        }

        public ActionResult BuscarPaciente()
		{
			return View(pacienteBD.obtenerListaPaciente());
		}

        [HttpPost]
		public ActionResult MostrarPaciente(PacienteModel pacienteParametro)
		{
            ViewData["generos"] = informacionBD.obtenerInformacionParametro("genero");
            ViewData["estados"] = informacionBD.obtenerInformacionParametro("estado civil");
            ViewData["tipos"] = informacionBD.obtenerInformacionParametro("tipo sangre");
            ViewData["etnias"] = informacionBD.obtenerInformacionParametro("etnia");
            return View(pacienteBD.obtenerPacientePorID(pacienteParametro.identificador));
		}

		public ActionResult ActualizarPaciente(PacienteModel pacienteParametro)
		{
            ViewData["generos"] = informacionBD.obtenerInformacionParametro("genero");
            ViewData["estados"] = informacionBD.obtenerInformacionParametro("estado civil");
            ViewData["tipos"] = informacionBD.obtenerInformacionParametro("tipo sangre");
            ViewData["etnias"] = informacionBD.obtenerInformacionParametro("etnia");
            return View(pacienteBD.obtenerPacientePorID(pacienteParametro.identificador));
        }

        public ActionResult ActualizarPacienteProceso(PacienteModel pacienteParametro)
        {
            pacienteBD.actualizarPaciente(pacienteParametro);
            ViewData["generos"] = informacionBD.obtenerInformacionParametro("genero");
            ViewData["estados"] = informacionBD.obtenerInformacionParametro("estado civil");
            ViewData["tipos"] = informacionBD.obtenerInformacionParametro("tipo sangre");
            ViewData["etnias"] = informacionBD.obtenerInformacionParametro("etnia");
            return View("ActualizarPaciente", pacienteBD.obtenerPacientePorID(pacienteParametro.identificador));
        }
    }
}