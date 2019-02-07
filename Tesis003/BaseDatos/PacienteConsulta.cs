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
    * Objeto utilizado para consultar los datos de la tabla paciente, se los retorna en un objeto ParametroModel
    * Base: DBVACARI
    * Tabla: Paciente
    **********/
    public class PacienteConsulta
    {
        
        //Conexion a la base de datos para realziar las consultas
        private ConexionBD conexion = new ConexionBD();

        //Constructor vacio
        public PacienteConsulta()
        {

        }

        public void ingresarPaciente(PacienteModel pacienteParametro)
        {
            string sql = "INSERT INTO PACIENTE (NumHistoriaClinica, NombreCompleto, Cedula, Direccion, Telefono, " +
                         "FechaNacimiento, Sexo, EstadoCivil, TipoSangre, Etnia, NombreContactoEmergencia, AfinidadContactoEmergencia, TelefonoContactoEmergencia) " +
                         "VALUES (@NumHistoriaClinica, @NombreCompleto, @Cedula, @Direccion, @Telefono, " +
                         "@FechaNacimiento, @Sexo, @EstadoCivil, @TipoSangre, @Etnia, @NombreContactoEmergencia, @AfinidadContactoEmergencia, @TelefonoContactoEmergencia)";

            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@NumHistoriaClinica", pacienteParametro.numHistoriaClinica);
            sentenciaSQL.Parameters.AddWithValue("@NombreCompleto", pacienteParametro.nombreCompleto);
            sentenciaSQL.Parameters.AddWithValue("@Cedula", pacienteParametro.cedula);
            sentenciaSQL.Parameters.AddWithValue("@Direccion", pacienteParametro.direccion);
            sentenciaSQL.Parameters.AddWithValue("@Telefono", pacienteParametro.telefono);
            sentenciaSQL.Parameters.AddWithValue("@FechaNacimiento", pacienteParametro.fechaNacimiento);
            sentenciaSQL.Parameters.AddWithValue("@Sexo", pacienteParametro.sexo);
            sentenciaSQL.Parameters.AddWithValue("@EstadoCivil", pacienteParametro.estadoCivil);
            sentenciaSQL.Parameters.AddWithValue("@TipoSangre", pacienteParametro.tipoSangre);
            sentenciaSQL.Parameters.AddWithValue("@Etnia", pacienteParametro.etnia);
            sentenciaSQL.Parameters.AddWithValue("@NombreContactoEmergencia", pacienteParametro.nombreContactoEmergencia);
            sentenciaSQL.Parameters.AddWithValue("@AfinidadContactoEmergencia", pacienteParametro.afinidadContactoEmergencia);
            sentenciaSQL.Parameters.AddWithValue("@TelefonoContactoEmergencia", pacienteParametro.telefonoContactoEmergencia);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public List<PacienteModel> obtenerListaPaciente()
        {
            List<PacienteModel> listaPacienteResultado = new List<PacienteModel>();

            string sentenciaSql = "SELECT TOP (15) PacienteID, NumHistoriaCLinica, NombreCompleto , Cedula " +
                                  "FROM PACIENTE " +
                                  "ORDER BY PacienteID DESC ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                PacienteModel pacienteResultado = new PacienteModel();
                pacienteResultado.identificador = tablaDatos.Rows[i].Field<int>("PacienteID");
                pacienteResultado.numHistoriaClinica = tablaDatos.Rows[i].Field<int>("NumHistoriaCLinica");
                pacienteResultado.nombreCompleto = tablaDatos.Rows[i].Field<string>("NombreCompleto");
                pacienteResultado.cedula = tablaDatos.Rows[i].Field<string>("Cedula");

                listaPacienteResultado.Add(pacienteResultado);
            }

            return listaPacienteResultado;
        }

        public PacienteModel obtenerPacientePorID(int identificador)
        {
            List<PacienteModel> listaPacienteResultado = new List<PacienteModel>();

            string sentenciaSql = "SELECT TOP (1) PacienteID, NumHistoriaClinica, NombreCompleto, Cedula, Direccion, Telefono, " +
                                  "FechaNacimiento, Sexo, EstadoCivil, TipoSangre, Etnia, NombreContactoEmergencia, AfinidadContactoEmergencia, TelefonoContactoEmergencia " +
                                  "FROM PACIENTE " +
                                  $"WHERE PacienteID = {identificador} ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            PacienteModel pacienteResultado = new PacienteModel();
            pacienteResultado.identificador = tablaDatos.Rows[0].Field<int>("PacienteID");
            pacienteResultado.numHistoriaClinica = tablaDatos.Rows[0].Field<int>("NumHistoriaCLinica");
            pacienteResultado.nombreCompleto = tablaDatos.Rows[0].Field<string>("NombreCompleto");
            pacienteResultado.cedula = tablaDatos.Rows[0].Field<string>("Cedula");
            pacienteResultado.direccion = tablaDatos.Rows[0].Field<string>("Direccion");
            pacienteResultado.telefono = tablaDatos.Rows[0].Field<string>("Telefono");
            pacienteResultado.fechaNacimiento = tablaDatos.Rows[0].Field<DateTime>("FechaNacimiento");
            pacienteResultado.sexo = tablaDatos.Rows[0].Field<int>("Sexo");
            pacienteResultado.estadoCivil = tablaDatos.Rows[0].Field<int>("EstadoCivil");
            pacienteResultado.tipoSangre = tablaDatos.Rows[0].Field<int>("TipoSangre");
            pacienteResultado.etnia = tablaDatos.Rows[0].Field<int>("Etnia");
            pacienteResultado.nombreContactoEmergencia = tablaDatos.Rows[0].Field<string>("NombreContactoEmergencia");
            pacienteResultado.afinidadContactoEmergencia = tablaDatos.Rows[0].Field<string>("AfinidadContactoEmergencia");
            pacienteResultado.telefonoContactoEmergencia = tablaDatos.Rows[0].Field<string>("TelefonoContactoEmergencia");

            return pacienteResultado;
        }

        public void actualizarPaciente(PacienteModel pacienteParametro)
        {
            string sql = "UPDATE PACIENTE " +
                         "SET NombreCompleto = @NombreCompleto, Cedula = @Cedula, Direccion = @Direccion, Telefono = @Telefono, " +
                         "FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, EstadoCivil = @EstadoCivil, TipoSangre = @TipoSangre, " +
                         "Etnia = @Etnia, NombreContactoEmergencia = @NombreContactoEmergencia, AfinidadContactoEmergencia = @AfinidadContactoEmergencia, " +
                         "TelefonoContactoEmergencia = @TelefonoContactoEmergencia " +
                         "WHERE PacienteID = @PacienteID";

            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@PacienteID", pacienteParametro.identificador);
            sentenciaSQL.Parameters.AddWithValue("@NombreCompleto", pacienteParametro.nombreCompleto);
            sentenciaSQL.Parameters.AddWithValue("@Cedula", pacienteParametro.cedula);
            sentenciaSQL.Parameters.AddWithValue("@Direccion", pacienteParametro.direccion);
            sentenciaSQL.Parameters.AddWithValue("@Telefono", pacienteParametro.telefono);
            sentenciaSQL.Parameters.AddWithValue("@FechaNacimiento", pacienteParametro.fechaNacimiento);
            sentenciaSQL.Parameters.AddWithValue("@Sexo", pacienteParametro.sexo);
            sentenciaSQL.Parameters.AddWithValue("@EstadoCivil", pacienteParametro.estadoCivil);
            sentenciaSQL.Parameters.AddWithValue("@TipoSangre", pacienteParametro.tipoSangre);
            sentenciaSQL.Parameters.AddWithValue("@Etnia", pacienteParametro.etnia);
            sentenciaSQL.Parameters.AddWithValue("@NombreContactoEmergencia", pacienteParametro.nombreContactoEmergencia);
            sentenciaSQL.Parameters.AddWithValue("@AfinidadContactoEmergencia", pacienteParametro.afinidadContactoEmergencia);
            sentenciaSQL.Parameters.AddWithValue("@TelefonoContactoEmergencia", pacienteParametro.telefonoContactoEmergencia);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }
    }
}