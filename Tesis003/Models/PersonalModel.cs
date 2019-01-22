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
     * Campos: PersonalID, Nombre, Cedula, Telefono ,Cargo ,Usuario, Contrasena, Especialidad
    **********/
    public class PersonalModel
    {
        //Nombre del usuario
        public string usuario { get; set; }

        //Contrasena del usuario
        public string contrasena { get; set; }

        //Identificardor del cargo del usuario
        public int cargo { get; set; }

        //Nombre del cargo del usuario
        public string cargoNombre { get; set; }

        //Identificador del usuario
        public int identificador { get; set; }

        //Nombre del usuario
        public string nombre { get; set; }

        //Cedula del usuario
        public string cedula { get; set; }

        //Telefono del usuario
        public string telefono { get; set; }
        
        //Especialidad del usuario
        public int especialidad { get; set; }
    }
}