using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tesis003.Models;

namespace Tesis003.BaseDatos
{
    /**********
    * Objeto utilizado para consultar los datos de la tabla parametros, se los retorna en un objeto ParametroModel
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

        //Funcion para obtener el identificardor y el valor del parametro de la base datos y los retorna en una lista de objetos ParametroModel
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

        //Funcion para obtener el siguiente numero de Historia Clinica
        public int obtenerSiguienteNumeroHistoriaClinica()
        {
            string sentenciaSql = "SELECT max(NumHistoriaClinica) as NumHistoriaClinica " +
                                  "FROM Paciente";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            int siguienteNumeroHistoriaCLinica = tablaDatos.Rows[0].Field<int>("NumHistoriaClinica") + 1;

            return siguienteNumeroHistoriaCLinica;
        }

        //Funcion para obtener el identificardor y el nombre del medico de la base datos y los retorna en una lista de objetos PersonalModel
        public List<PersonalModel> obtenerListaMedico()
        {
            List<PersonalModel> listaMediocoResultado = new List<PersonalModel>();

            string sentenciaSql = "SELECT PersonalID, Nombre " +
                                  "FROM Personal "+
                                  "WHERE Cargo = 21 ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                PersonalModel personalResultado = new PersonalModel();
                personalResultado.identificador = tablaDatos.Rows[i].Field<int>("PersonalID");
                personalResultado.nombre = tablaDatos.Rows[i].Field<string>("Nombre").Replace("_", " ");

                listaMediocoResultado.Add(personalResultado);
            }

            return listaMediocoResultado;
        }
    }
}