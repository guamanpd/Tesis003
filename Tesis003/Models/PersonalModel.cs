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
        //Nombre del personal
        public string usuario { get; set; }

        //Contrasena del personal
        public string contrasena { get; set; }

        //Identificardor del cargo del personal
        public int cargo { get; set; }

        //Nombre del cargo del personal
        public string cargoNombre { get; set; }

        //Identificador del personal
        public int identificador { get; set; }

        //Nombre del personal
        public string nombre { get; set; }

        //Cedula del personal
        public string cedula { get; set; }

        //Telefono del personal
        public string telefono { get; set; }

        //Especialidad del personal
        public int especialidad { get; set; }

        //Servicios del personal
        public List<ServicioModel> servicios { get; set; }
    }
}