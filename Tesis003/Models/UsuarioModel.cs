using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis003.Models
{
    /**********
     * Objeto utilziado para guardar los datos del usuario
     * Base: DBVACARI
     * Tabla: Personal
     * Campos: Usuario, Contrasena
    **********/
    public class UsuarioModel
    {
        //Nombre del usuario
        public string usuario { get; set; }

        //Contrasena del usuario
        public string contrasena { get; set; }

        //Contrasena del usuario
        public int cargo { get; set; }

        //Identificador del usuario
        public int identificador { get; set; }
    }
}