using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Tesis003.BaseDatos
{
    /**********
     * Clase utilizada para conectarse a la base de datos
     * Gestor de Base de Datos: SQLSERVER 
     * Servidor: 192.168.56.101
     * Base: DBVACARI
     * Usuario: sa
     * Contraseña: Tesis2018
     **********/
    public class ConexionBD
    {
        //String con todos los parametros que se utiliza para la conexion a la base de datos.
        private string stringConexion = "data source = 192.168.56.101; initial catalog = DBVACARI; user id = sa; password = Tesis2018";

        /*//Se genera la conexion a la base de datos.
        public SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(this.stringConexion);
            return conexion;
        }
        */

        //Se ejecuta una sentencia SQL del tipo SELECT en la base de datos.
        public void ComandoConsulta(SqlCommand sentenciaSQL)
        {
            try
            {
                sentenciaSQL.Connection = new SqlConnection(this.stringConexion);
                sentenciaSQL.Connection.Open();

                SqlDataReader resultado = sentenciaSQL.ExecuteReader();
                while (resultado.Read())
                {

                }
                sentenciaSQL.Connection.Close();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error en la clase: ConexionBD, metodo: ComandoConsulta().");
                Trace.WriteLine("Error al ejecutar la senteciaSQL de modificaion.");
                Trace.WriteLine($"Sentencia: {sentenciaSQL}.");
                Trace.WriteLine(e.Message);
                Trace.Flush();
            }
        }

        //Se ejecuta una sentencia SQL del tipo INSERT, UPDATE o DELETE en la base de datos.
        public void ComandoModificacion(SqlCommand sentenciaSQL)
        {
            try
            {
                sentenciaSQL.Connection = new SqlConnection(this.stringConexion);
                sentenciaSQL.Connection.Open();
                sentenciaSQL.ExecuteNonQuery();
                sentenciaSQL.Connection.Close();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error en la clase: ConexionBD, metodo: ComandoModificacion().");
                Trace.WriteLine("Error al ejecutar la senteciaSQL de modificaion.");
                Trace.WriteLine($"Sentencia: {sentenciaSQL}.");
                Trace.WriteLine(e.Message);
                Trace.Flush();
            }
        }
    }
}