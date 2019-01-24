using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis003.Models
{
    /**********
     * Objeto utilziado para guardar los datos de los servicos del personal
     * Base: DBVACARI
     * Tabla: Servicio
     * Campos: ServicioID, PersonalID, Detalle, Valor
    **********/
    public class ServicioModel
    {
        //Identificador del servicio
        public int identificador { get; set; }

        //Identificador del usuario
        public int identificadorPersonal { get; set; }

        //Detalle del servicio
        public string detalle { get; set; }

        //Valor del servicio
        public decimal valor { get; set; }
    }
}