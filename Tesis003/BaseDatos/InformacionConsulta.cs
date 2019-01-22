using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tesis003.Models;

namespace Tesis003.BaseDatos
{
    /**********
    * Objeto utilziada para consultar los datos del usuario y almacenarlos en un objeto UsuarioModel
    * Base: DBVACARI
    * Tabla: Parametro
    **********/
    public class InformacionConsulta
    {
        
        //Conexion a la base de datos para realziar las consultas
        private ConexionBD conexion = new ConexionBD();

        //Constructor vacio
        public InformacionConsulta()
        {

        }

        //Funcion para obtener el identificardor y el valor del parametro de la base datos, los retorna en una lista de objetos ParametroModel
        public List<ParametroModel> obtenerInformacionParametro(string tipo)
        {
            List<ParametroModel> listaParametroResultado = new List<ParametroModel>();

            string sentenciaSql = "SELECT ParametroID, Valor " +
                                  "FROM Parametro " +
                                  $"WHERE Tipo like '{tipo}' ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                ParametroModel parametroResultado = new ParametroModel();
                parametroResultado.identificador = tablaDatos.Rows[i].Field<int>("ParametroID");
                parametroResultado.valor = tablaDatos.Rows[i].Field<string>("Valor").Replace("_"," ");

                listaParametroResultado.Add(parametroResultado);
            }

            return listaParametroResultado;
        }
    }
}