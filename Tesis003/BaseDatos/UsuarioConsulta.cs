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

        //Funcion para obtener el identificardor, el usuario y la contrasena de la base datos, los retorna en un objeto UsuarioModel
        public UsuarioModel obtenerInformacionIngreso(string usuario)
        {
            UsuarioModel usuarioResultado = new UsuarioModel();

            string sentenciaSql = "SELECT TOP(1) PersonalID, Usuario, Contrasena, Cargo " +
                                  "FROM Personal " +
                                  $"WHERE Usuario like '{usuario}' ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.identificador = tablaDatos.Rows[0].Field<int>("PersonalID");
            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.contrasena = tablaDatos.Rows[0].Field<string>("Contrasena");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");

            return usuarioResultado;
        }

        //Funcion para obtener el usuario, el cargo y el identificador de la base datos, los retorna en un objeto UsuarioModel
        public UsuarioModel obtenerInformacionAdicional(string usuario)
        {
            UsuarioModel usuarioResultado = new UsuarioModel();

            string sentenciaSql = "SELECT TOP(1) PersonalID, Usuario, Cargo " +
                                  "FROM Personal " +
                                  $"WHERE Usuario like '{usuario}' ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.identificador = tablaDatos.Rows[0].Field<int>("PersonalID");
            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");

            return usuarioResultado;
        }
    }
}