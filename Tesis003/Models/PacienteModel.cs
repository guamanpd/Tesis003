using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis003.Models
{
    /**********
     * Objeto utilziado para guardar los datos del paciente
     * Base: DBVACARI
     * Tabla: Paciente
     * Campos: PacienteID, NumHistoriaClinica, NombreCompleto, Cedula, Direccion, Telefono, FechaNacimiento, Sexo, EstadoCivil, TipoSangre, Nacionalidad, Etnia, NombreContactoEmergencia, AfinidadContactoEmergencia, TelefonoContactoEmergencia
    **********/
    public class PacienteModel
    {
        //Identificador
        public int identificador { get; set; }

        //Numero de Historia clinica
        public int numHistoriaClinica { get; set; }

        //Nombre del paciente
        public string nombreCompleto { get; set; }

        //Cedula del paciente
        public string cedula { get; set; }

        //Direccion del paciente
        public string direccion { get; set; }

        //Telefono del paciente
        public string telefono { get; set; }

        //Fecha de nacimiento del paciente
        public DateTime fechaNacimiento { get; set; }

        //Sexo del paciente
        public int sexo { get; set; }

        //Estado civil del paciente
        public int estadoCivil { get; set; }

        //Tipo de sangre del paciente
        public int tipoSangre { get; set; }

        //Etnia del paciente
        public int etnia { get; set; }

        //Telefono del paciente
        public string nombreContactoEmergencia { get; set; }

        //Telefono del paciente
        public string afinidadContactoEmergencia { get; set; }

        //Telefono del paciente
        public string telefonoContactoEmergencia { get; set; }
    }
}