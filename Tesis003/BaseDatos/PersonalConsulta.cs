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
     * Objeto utilziada para consultar los datos del usuario y almacenarlos en un objeto PersonalModel
     * Base: DBVACARI
     * Tabla: Personal
    **********/
    public class PersonalConsulta
    {
        //Conexion a la base de datos para realziar las consultas
        private ConexionBD conexion = new ConexionBD();

        //Constructor vacio
        public PersonalConsulta()
        {

        }

        //Funcion para obtener el identificardor, el usuario y la contrasena de la base datos, los retorna en un objeto PersonalModel
        public PersonalModel obtenerInformacionIngreso(string usuario)
        {
            PersonalModel usuarioResultado = new PersonalModel();

            string sentenciaSql = "SELECT TOP(1) Usuario, Contrasena, Cargo " +
                                  "FROM Personal " +
                                  $"WHERE Usuario like '{usuario}' ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.contrasena = tablaDatos.Rows[0].Field<string>("Contrasena");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");

            return usuarioResultado;
        }

        //Funcion para obtener el usuario, el cargo y el identificador de la base datos, los retorna en un objeto PersonalModel
        public PersonalModel obtenerInformacionUsuario(int identificador)
        {
            PersonalModel usuarioResultado = new PersonalModel();

            string sentenciaSql = "SELECT TOP(1) PersonalID, Nombre, Cedula, Telefono ,Cargo ,Usuario, Contrasena, Especialidad " +
                                  "FROM Personal " +
                                  $"WHERE PersonalID = {identificador} ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.identificador = tablaDatos.Rows[0].Field<int>("PersonalID");
            usuarioResultado.nombre = tablaDatos.Rows[0].Field<string>("Nombre");
            usuarioResultado.cedula = tablaDatos.Rows[0].Field<string>("Cedula");
            usuarioResultado.telefono = tablaDatos.Rows[0].Field<string>("Telefono");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");            
            usuarioResultado.usuario = tablaDatos.Rows[0].Field<string>("Usuario");
            usuarioResultado.contrasena = tablaDatos.Rows[0].Field<string>("Contrasena");
            //usuarioResultado.especialidad = tablaDatos.Rows[0].Field<int>("Especialidad");

            return usuarioResultado;
        }

        public List<PersonalModel> obtenerListaUsuario()
        {
            List<PersonalModel> listaUsuarioResultado = new List<PersonalModel>();         

            string sentenciaSql = "SELECT PersonalID, Nombre, Telefono , par.Valor as Cargo " +
                                  "FROM Personal per inner join Parametro par " +
                                  "ON per.cargo = par.ParametroID ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i=0; i < tablaDatos.Rows.Count; i++)
            {
                PersonalModel usuarioResultado = new PersonalModel();
                usuarioResultado.identificador = tablaDatos.Rows[i].Field<int>("PersonalID");
                usuarioResultado.nombre = tablaDatos.Rows[i].Field<string>("Nombre");
                usuarioResultado.telefono = tablaDatos.Rows[i].Field<string>("Telefono");
                usuarioResultado.cargoNombre = tablaDatos.Rows[i].Field<string>("Cargo");

                listaUsuarioResultado.Add(usuarioResultado);
            }            

            return listaUsuarioResultado;
        }

        public void ingresarPersonal(PersonalModel personalParametro)
        {
            string sql = "INSERT INTO PERSONAL (Nombre, Cedula, Telefono, Cargo, Usuario, Contrasena) " +
                         "VALUES (@Nombre, @Cedula, @Telefono, @Cargo, @Usuario, @Contrasena)";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@Nombre", personalParametro.nombre);
            sentenciaSQL.Parameters.AddWithValue("@Cedula", personalParametro.cedula);
            sentenciaSQL.Parameters.AddWithValue("@Telefono", personalParametro.telefono);
            sentenciaSQL.Parameters.AddWithValue("@Cargo", personalParametro.cargo);
            sentenciaSQL.Parameters.AddWithValue("@Usuario", personalParametro.usuario);
            sentenciaSQL.Parameters.AddWithValue("@Contrasena", personalParametro.contrasena);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public void actualizarPersonal(PersonalModel personalParametro)
        {
            string sql = "UPDATE PERSONAL " +
                         "SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono, Cargo = @Cargo, Usuario = @Usuario, Contrasena = @Contrasena " +
                         "WHERE PersonalID = @PersonalID";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@PersonalID", personalParametro.identificador);
            sentenciaSQL.Parameters.AddWithValue("@Nombre", personalParametro.nombre);
            sentenciaSQL.Parameters.AddWithValue("@Cedula", personalParametro.cedula);
            sentenciaSQL.Parameters.AddWithValue("@Telefono", personalParametro.telefono);
            sentenciaSQL.Parameters.AddWithValue("@Cargo", personalParametro.cargo);
            sentenciaSQL.Parameters.AddWithValue("@Usuario", personalParametro.usuario);
            sentenciaSQL.Parameters.AddWithValue("@Contrasena", personalParametro.contrasena);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public PersonalModel obtenerInformacionPersonalServicio(int identificador)
        {
            PersonalModel usuarioResultado = new PersonalModel();

            string sentenciaSql = "SELECT TOP(1) PersonalID, Nombre, Cedula, Telefono ,Cargo " +
                                  "FROM Personal " +
                                  $"WHERE PersonalID = {identificador} ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            usuarioResultado.identificador = tablaDatos.Rows[0].Field<int>("PersonalID");
            usuarioResultado.nombre = tablaDatos.Rows[0].Field<string>("Nombre");
            usuarioResultado.cedula = tablaDatos.Rows[0].Field<string>("Cedula");
            usuarioResultado.telefono = tablaDatos.Rows[0].Field<string>("Telefono");
            usuarioResultado.cargo = tablaDatos.Rows[0].Field<int>("Cargo");

            List<ServicioModel> listaPersonalServicioResultado = new List<ServicioModel>();

            sentenciaSql = "SELECT ServicioID, PersonalID, Detalle, Valor " +
                           "FROM Servicio " +
                           $"WHERE PersonalID = {identificador} ";

            tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                ServicioModel servicioResultado = new ServicioModel();
                servicioResultado.identificador = tablaDatos.Rows[i].Field<int>("ServicioID");
                servicioResultado.identificadorPersonal = tablaDatos.Rows[i].Field<int>("PersonalID");
                servicioResultado.detalle = tablaDatos.Rows[i].Field<string>("Detalle");
                servicioResultado.valor = tablaDatos.Rows[i].Field<decimal>("Valor");

                listaPersonalServicioResultado.Add(servicioResultado);
            }

            usuarioResultado.servicios = listaPersonalServicioResultado;

            return usuarioResultado;
        }

        public void ingresarServicio(ServicioModel servicioParametro)
        {
            string sql = "INSERT INTO SERVICIO (PersonalID, Detalle, Valor) " +
                         "VALUES (@PersonalID, @Detalle, @Valor)";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@PersonalID", servicioParametro.identificadorPersonal);
            sentenciaSQL.Parameters.AddWithValue("@Detalle", servicioParametro.detalle);
            sentenciaSQL.Parameters.AddWithValue("@Valor", servicioParametro.valor);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public void actualizarServicio(ServicioModel servicioParametro)
        {
            string sql = "UPDATE SERVICIO " +
                         "SET Detalle = @Detalle, Valor = @Valor " +
                         "WHERE ServicioID = @ServicioID";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@ServicioID", servicioParametro.identificador);
            sentenciaSQL.Parameters.AddWithValue("@Detalle", servicioParametro.detalle);
            sentenciaSQL.Parameters.AddWithValue("@Valor", servicioParametro.valor);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public void eliminarServicio(ServicioModel servicioParametro)
        {
            string sql = "DELETE " +
                         "FROM SERVICIO " +
                         "WHERE ServicioID = @ServicioID";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@ServicioID", servicioParametro.identificador);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }
    }
}