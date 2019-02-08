using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesis003.BaseDatos;
using Tesis003.Models;

namespace Tesis003.Controllers
{
    public class CitaController : Controller
    {
        PersonalConsulta personalBD = new PersonalConsulta();
        InformacionConsulta informacionBD = new InformacionConsulta();
        PacienteConsulta pacienteBD = new PacienteConsulta();
        CitaConsulta citaBD = new CitaConsulta();


        // GET: Cita
        public ActionResult IngresarCita(CitaModel citaParametro)
        {
            CitaPacienteModel cita = new CitaPacienteModel();
            cita.citaspaciente = citaBD.obtenerListaCitaPaciente(citaParametro.identificadorPaciente);
            cita.paciente = pacienteBD.obtenerPacientePorID(citaParametro.identificadorPaciente);
            ViewData["medicos"] = informacionBD.obtenerListaMedico();
            ViewData["especialidades"] = informacionBD.obtenerInformacionParametro("especialidad");
            ViewData["tiposCita"] = informacionBD.obtenerInformacionParametro("tipo cita");
            return View(cita);
        }

        public ActionResult IngresarCitaProceso(CitaModel citaParametro)
        {
            citaBD.ingresarCita(citaParametro);            
            CitaPacienteModel cita = new CitaPacienteModel();
            cita.citaspaciente = citaBD.obtenerListaCitaPaciente(citaParametro.identificadorPaciente);
            cita.paciente = pacienteBD.obtenerPacientePorID(citaParametro.identificadorPaciente);
            ViewData["medicos"] = informacionBD.obtenerListaMedico();
            ViewData["especialidades"] = informacionBD.obtenerInformacionParametro("especialidad");
            ViewData["tiposCita"] = informacionBD.obtenerInformacionParametro("tipo cita");
            return View("IngresarCita", cita);
        }

        public ActionResult EliminarCitaProceso(CitaModel citaParametro)
        {
            citaBD.eliminarCita(citaParametro);
            CitaPacienteModel cita = new CitaPacienteModel();
            cita.citaspaciente = citaBD.obtenerListaCitaPaciente(citaParametro.identificadorPaciente);
            cita.paciente = pacienteBD.obtenerPacientePorID(citaParametro.identificadorPaciente);
            ViewData["medicos"] = informacionBD.obtenerListaMedico();
            ViewData["especialidades"] = informacionBD.obtenerInformacionParametro("especialidad");
            ViewData["tiposCita"] = informacionBD.obtenerInformacionParametro("tipo cita");
            return View("IngresarCita", cita);
        }

        public ActionResult ListarCita()
		{
            List<CitaModel> listaCitas = new List<CitaModel>();
            listaCitas = citaBD.obtenerListaCita();
			return View(listaCitas);
		}
	}
}