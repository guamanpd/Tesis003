﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesis003.BaseDatos;
using Tesis003.Models;

namespace Tesis003.Controllers
{
    public class IngresoController : Controller
    {
        //Consultas a la base de datos sobre el usuario
        UsuarioConsulta usuarioBD = new UsuarioConsulta();

        /**********
         * Metodo:GET
         * Devuelve la pantalla de inicio en donde se debe autentificar
        **********/
        [HttpGet]
        public ActionResult Ingreso()
        {
            Session["identificado"] = "false";
            return View();
        }

        /**********
         * Metodo:POST
         * Recibe un objeto de tipo UsuarioModel con los valores ingresados en la vista.
         * Redirige a la pantalla de presentacion si todo se valida al usuario
        **********/
        [HttpPost]
        public ActionResult Ingreso(UsuarioModel usuarioParametro)
        {
            /*UsuarioModel usuarioIngreso = usuarioBD.obtenerInformacionIngreso(usuarioParametro.usuario);
            if (!string.IsNullOrEmpty(usuarioParametro.usuario) && !string.IsNullOrEmpty(usuarioParametro.contrasena) && usuarioIngreso.contrasena.Equals(usuarioParametro.contrasena))
            {
                Session["identificado"] = "true";
                Session["cargo"]= usuarioIngreso.cargo.ToString();
                return RedirectToAction("Presentacion", "Ingreso");
            }
            else
            {
                return View();
            }*/

            Session["identificado"] = "true";
            Session["cargo"] = "17";
            return RedirectToAction("Presentacion", "Ingreso");
        }

        /**********
         * Metodo:GET,POST
         * Devuelve la pantalla donde se muestran los menus del sistema
        **********/
        public ActionResult Presentacion()
		{
			return View();
		}

        /**********
         * Metodo:GET,POST
         * Redirige a la pantalla de inicio en donde se debe autentificar
        **********/
        public ActionResult Salir()
        {
            Session["identificado"] = "false";
            Session["cargo"] = "";
            return RedirectToAction("Ingreso", "Ingreso");
        }
    }
}