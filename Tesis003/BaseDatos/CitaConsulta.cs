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
    * Objeto utilizado para consultar los datos de la tabla paciente, se los retorna en un objeto CitaModel
    * Base: DBVACARI
    * Tabla: Cita
    **********/
    public class CitaConsulta
    {
        
        //Conexion a la base de datos para realziar las consultas
        private ConexionBD conexion = new ConexionBD();

        //Constructor vacio
        public CitaConsulta()
        {

        }

        public void ingresarCita(CitaModel pacienteParametro)
        {
            string sql = "INSERT INTO CITAMEDICA (PacienteID,Fecha,TipoCita,PersonalID,Pagado,Atencion,Enfermeria) " +
                         "VALUES (@PacienteID,@Fecha,@TipoCita,@PersonalID,@Pagado,@Atencion,@Enfermeria) ";

            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@PacienteID", pacienteParametro.identificadorPaciente);
            sentenciaSQL.Parameters.AddWithValue("@Fecha", pacienteParametro.fecha);
            sentenciaSQL.Parameters.AddWithValue("@TipoCita", pacienteParametro.tipoCita);
            sentenciaSQL.Parameters.AddWithValue("@PersonalID", pacienteParametro.identificadorPersonal);
            sentenciaSQL.Parameters.AddWithValue("@Pagado", pacienteParametro.pagado);
            sentenciaSQL.Parameters.AddWithValue("@Atencion", pacienteParametro.atencion);
            sentenciaSQL.Parameters.AddWithValue("@Enfermeria", pacienteParametro.enfermeria);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public List<CitaModel> obtenerListaCitaPaciente (int identificadorPaciente)
        {
            List<CitaModel> listaCitaPacienteResultado = new List<CitaModel>();

            string sentenciaSql = "SELECT cm.CitaMedicaID, pac.NombreCompleto as NombreCompletoPaciente, pac.Cedula as CedulaPaciente, cm.Fecha, par.Valor as NombreTipoCita, parm.Valor as NombreCargo, per.Nombre as NombrePersonal, cm.Pagado, cm.Atencion, cm.Enfermeria "+
                                  "FROM CITAMEDICA cm INNER JOIN PERSONAL per "+
                                  "ON cm.PersonalID = per.PersonalID "+
                                  "INNER JOIN PARAMETRO par "+
                                  "ON cm.TipoCita = par.ParametroID "+
                                  "INNER JOIN Paciente pac "+
                                  "ON cm.PacienteID = pac.PacienteID "+
                                  "INNER JOIN PARAMETRO parm "+
                                  "ON per.Cargo = parm.ParametroID "+
                                  $"WHERE cm.PacienteID = {identificadorPaciente} "+
                                  "ORDER BY Fecha DESC ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                CitaModel citaResultado = new CitaModel();
                citaResultado.identificador = tablaDatos.Rows[i].Field<int>("CitaMedicaID");
                citaResultado.fecha = tablaDatos.Rows[i].Field<DateTime>("Fecha");
                citaResultado.nombreTipoCita = tablaDatos.Rows[i].Field<string>("NombreTipoCita").Replace("_"," ");
                citaResultado.nombrePersonal = tablaDatos.Rows[i].Field<string>("NombrePersonal");
                citaResultado.nombreCargo = tablaDatos.Rows[i].Field<string>("NombreCargo");
                citaResultado.pagado = tablaDatos.Rows[i].Field<bool>("Pagado");
                citaResultado.atencion = tablaDatos.Rows[i].Field<bool>("Atencion");
                citaResultado.enfermeria = tablaDatos.Rows[i].Field<bool>("Enfermeria");

                listaCitaPacienteResultado.Add(citaResultado);
            }
            return listaCitaPacienteResultado;
        }

        public void eliminarCita(CitaModel citaParametro)
        {
            string sql = "DELETE " +
                         "FROM CITAMEDICA " +
                         "WHERE CitaMedicaID = @CitaMedicaID";
            SqlCommand sentenciaSQL = new SqlCommand(sql);

            sentenciaSQL.Parameters.AddWithValue("@CitaMedicaID", citaParametro.identificador);

            this.conexion.ComandoModificacion(sentenciaSQL);
        }

        public List<CitaModel> obtenerListaCita()
        {
            List<CitaModel> listaCitaPacienteResultado = new List<CitaModel>();

            string sentenciaSql = "SELECT cm.CitaMedicaID, pac.NombreCompleto as NombreCompletoPaciente, pac.Cedula as CedulaPaciente, pac.NumHistoriaClinica as NumHistoriaClinica, cm.Fecha, par.Valor as NombreTipoCita, parm.Valor as NombreCargo, per.Nombre as NombrePersonal, cm.Pagado, cm.Atencion, cm.Enfermeria " +
                                  "FROM CITAMEDICA cm INNER JOIN PERSONAL per " +
                                  "ON cm.PersonalID = per.PersonalID " +
                                  "INNER JOIN PARAMETRO par " +
                                  "ON cm.TipoCita = par.ParametroID " +
                                  "INNER JOIN Paciente pac " +
                                  "ON cm.PacienteID = pac.PacienteID " +
                                  "INNER JOIN PARAMETRO parm " +
                                  "ON per.Cargo = parm.ParametroID " +
                                  "ORDER BY Fecha DESC ";

            DataTable tablaDatos = this.conexion.ComandoConsulta(sentenciaSql);

            for (int i = 0; i < tablaDatos.Rows.Count; i++)
            {
                CitaModel citaResultado = new CitaModel();
                citaResultado.identificador = tablaDatos.Rows[i].Field<int>("CitaMedicaID");
                citaResultado.numHistoriaClinica = tablaDatos.Rows[i].Field<int>("NumHistoriaClinica");
                citaResultado.fecha = tablaDatos.Rows[i].Field<DateTime>("Fecha");
                citaResultado.nombreCompletoPaciente = tablaDatos.Rows[i].Field<string>("NombreCompletoPaciente");
                citaResultado.nombreTipoCita = tablaDatos.Rows[i].Field<string>("NombreTipoCita").Replace("_", " ");
                citaResultado.nombrePersonal = tablaDatos.Rows[i].Field<string>("NombrePersonal");
                citaResultado.cedulaPaciente = tablaDatos.Rows[i].Field<string>("CedulaPaciente");
                citaResultado.nombreCargo = tablaDatos.Rows[i].Field<string>("NombreCargo");
                citaResultado.pagado = tablaDatos.Rows[i].Field<bool>("Pagado");
                citaResultado.atencion = tablaDatos.Rows[i].Field<bool>("Atencion");
                citaResultado.enfermeria = tablaDatos.Rows[i].Field<bool>("Enfermeria");

                listaCitaPacienteResultado.Add(citaResultado);
            }
            return listaCitaPacienteResultado;
        }
    }
}