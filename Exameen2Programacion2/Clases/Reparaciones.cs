using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace Exameen2Programacion2.Clases
{
    public class Reparaciones
    {
        public static int ReparacionID { get; set; }
        public static string EquipoID { get; set; }
        public static string FechaSolicitud { get; set; }
        public static string Estado { get; set; }
        public static string AsignacionID { get; set; }

        public Reparaciones(int reparacionID, string equipoID, string fechaSolicitud, string estado, string asignacionID)
        {
            ReparacionID = reparacionID;
            EquipoID = equipoID;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
            AsignacionID = asignacionID;
        }

        public Reparaciones() { }

        public static int INSERTAR_REPARACION(string equipoID, string fechaSolicitud, string estado, string asignacionID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_REPARACION", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPO_ID", EquipoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_SOLICITUD", FechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", Estado));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACION_ID", AsignacionID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;
        }

        public static int BORRAR_REPARACIONES_ID(int reparacionID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_REPARACIONES_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", reparacionID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;
        }

        public static int ACTUALIZAR_REPARACION_ID(int ID, string equipoID, string fechaSolicitud, string estado, string asignacionID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_REPARACION_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPO_ID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_SOLICITUD", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACION_ID", asignacionID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;
        }
    }
}