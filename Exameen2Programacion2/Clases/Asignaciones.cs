using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Exameen2Programacion2.Clases;

namespace Exameen2Programacion2.Clases
{
    public class Asignaciones
    {
        public static int AsignacionID { get; set; }
        public static string TecnicoID { get; set; }
        public static string ReparacionID { get; set; }
        public static string FechaAsignacion { get; set; }

        public Asignaciones(int asignacionID, string tecnicoID, string reparacionID, string fechaAsignacion)
        {
            AsignacionID = asignacionID;
            TecnicoID = tecnicoID;
            ReparacionID = reparacionID;
            FechaAsignacion = fechaAsignacion;
        }

        public Asignaciones() { }

        public static int INSERTAR_ASIGNACIONES(string tecnicoID, string reparacionID, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_ASIGNACION", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TECNICO_ID", TecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@REPARACION_ID", ReparacionID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_ASIGNACION", FechaAsignacion));

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

        public static int BORRAR_ASIGNACIONES_ID(int asignacionID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_ASIGNACIONES_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", asignacionID));

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

        public static int ACTUALIZAR_ASIGNACIONES_ID(int ID, string tecnicoID, string reparacionID, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_ASIGNACION_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.Parameters.Add(new SqlParameter("@TECNICO_ID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@REPARACION_ID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_ASIGNACION", fechaAsignacion));

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
