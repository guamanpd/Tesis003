using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis003.Models
{
    /**********
     * Objeto utilziado para guardar los datos de los parametros
     * Base: DBVACARI
     * Tabla: Perametro
     * Campos: ParametroID, Tipo, Valor
    **********/
    public class ParametroModel
    {
        //Identificador del parametro
        public int identificador { get; set; }
        
        //Tipo del parametro
        public string tipo { get; set; }

        //Valor del parametro
        public string valor { get; set; }

    }
}