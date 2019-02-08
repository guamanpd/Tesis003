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
    public class CitaPacienteModel
    {
        //Paciente
        public PacienteModel paciente { get; set; }

        //Lista de cita del paciente
        public List<CitaModel> citaspaciente { get; set; }
    }
}