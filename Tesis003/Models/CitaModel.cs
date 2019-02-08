using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis003.Models
{
    /**********
     * Objeto utilziado para guardar los datos de la cita medica
     * Base: DBVACARI
     * Tabla: CitaMedica
     * Campos: CitaMedicaID, PacienteID, Fecha, TipoCita, PersonalID, Pagado, Atencion, Enfermeria
    **********/
    public class CitaModel
    {
        //Identificador del cita medica
        public int identificador { get; set; }

        //Identificador del paciente
        public int identificadorPaciente { get; set; }

        //Numero de historia clinica
        public int numHistoriaClinica { get; set; }

        //Nombre del paciente
        public string nombreCompletoPaciente { get; set; }

        //Identificador del personal
        public int identificadorPersonal { get; set; }

        //Nombre del personal
        public string nombrePersonal { get; set; }

        //Fecha de la cita 
        public DateTime fecha { get; set; }

        //Tipo de cita medica
        public int tipoCita { get; set; }

        //Nombre de cita medica
        public string nombreTipoCita { get; set; }

        //Estado pagado
        public Boolean pagado { get; set; }

        //Estado atencion
        public Boolean atencion { get; set; }

        //Estado enfermeria
        public Boolean enfermeria { get; set; }

        //Nombre del cargo 
        public string nombreCargo { get; set; }

        //Cedula Paciente
        public string cedulaPaciente { get; set; }
    }
}