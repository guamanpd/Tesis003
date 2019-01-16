using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tesis003.Models;

namespace Tesis003.BaseDatos
{
    /**********
     * Objeto utilziada para consultar los datos del usuario y almacenarlos en un objeto UsuarioModel
     * Base: DBVACARI
     * Tabla: Personal
    **********/
    public class UsuarioConsulta
    {
        //Conexion a la base de datos para realziar las consultas
        private ConexionBD conexion = new ConexionBD();

        //Constructor vacio
        public UsuarioConsulta()
        {

        }

        //Funcion para obtener el usuario y la contrasena de la base datos, los retorna en un objeto UsuarioModel
        public UsuarioModel obtenerUsuario(string usuario)
        {
            UsuarioModel usuarioResultado = new UsuarioModel();

            string sql = "SELECT Usuario, Contrasena "+
                         "FROM Personal "+
                         "WHERE Usuario like '@Usuario' "+
                         "LIMIT 0,1";

            SqlCommand sentenciaSql = new SqlCommand(sql);
            sentenciaSql.Parameters.AddWithValue("@Usuario",usuario);

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.contrasena = tablaDatos.Rows[0].Field<string>("Contrasena");

            return usuarioResultado;
        }

        //Funcion para obtener el usuario, el cargo y el identificador de la base datos, los retorna en un objeto UsuarioModel
        public UsuarioModel obtenerInformacionUsuario(string usuario)
        {
            UsuarioModel usuarioResultado = new UsuarioModel();

            string sql = "SELECT  PersonalID, Usuario, Cargo " +
                         "FROM Personal " +
                         "WHERE Usuario like '@Usuario' " +
                         "LIMIT 0,1";

            SqlCommand sentenciaSql = new SqlCommand(sql);
            sentenciaSql.Parameters.AddWithValue("@Usuario", usuario);

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.identificador = tablaDatos.Rows[0].Field<int>("PersonalID");
            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");

            return usuarioResultado;
        }
    }
}