using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesis003.BaseDatos;
using Tesis003.Models;

namespace Tesis003.Controllers
{
    public class PersonalController : Controller
    {
        PersonalConsulta usuarioBD = new PersonalConsulta();
        InformacionConsulta informacionBD = new InformacionConsulta();

        // GET: Personal
        [HttpGet]
        public ActionResult IngresarPersonal()
        {
            ViewData["cargos"] = informacionBD.obtenerInformacionParametro("cargo");
            return View();
        }

        [HttpPost]
        public ActionResult IngresarPersonal(PersonalModel usuarioParametro)
        {
            if (!string.IsNullOrEmpty(usuarioParametro.nombre) && !string.IsNullOrEmpty(usuarioParametro.cedula) && !string.IsNullOrEmpty(usuarioParametro.telefono) && !string.IsNullOrEmpty(usuarioParametro.usuario) && !string.IsNullOrEmpty(usuarioParametro.contrasena) && usuarioParametro.cargo > 0)
            {
                usuarioBD.ingresarPersonal(usuarioParametro);
            }
            ViewData["cargos"] = informacionBD.obtenerInformacionParametro("cargo");
            return View();
        }

        [HttpGet]
		public ActionResult ListarPersonal()
		{
            List<PersonalModel> listaUsuario = usuarioBD.obtenerListaUsuario();
            return View(listaUsuario);
		}

        [HttpPost]
        public ActionResult ActualizarPersonal(int identificador)
		{
            ViewData["cargos"] = informacionBD.obtenerInformacionParametro("cargo");
            PersonalModel personal = usuarioBD.obtenerInformacionUsuario(identificador);
            return View(personal);
		}

        [HttpPost]
        public ActionResult ActualizarPersonalProceso(PersonalModel personalParametro)
        {
            ViewData["cargos"] = informacionBD.obtenerInformacionParametro("cargo");
            usuarioBD.actualizarPersonal(personalParametro);
            PersonalModel personal = usuarioBD.obtenerInformacionUsuario(personalParametro.identificador);
            return View("ActualizarPersonal", personal);
        }
    }
}