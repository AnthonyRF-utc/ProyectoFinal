using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace Exameen2Programacion2.Clases
{
    public class DetallesReparaciones
    {
        public static int DetallesReparacionesID { get; set; }
        public static string ReparacionID { get; set; }
        public static string Descripcion { get; set; }
        public static string FechaInicio { get; set; }
        public static string FechaFin { get; set; }

        public DetallesReparaciones(int detallesReparacionesID, string reparacionID, string descripcion, string fechaInicio, string fechaFin)
        {
            DetallesReparacionesID = detallesReparacionesID;
            ReparacionID = reparacionID;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public DetallesReparaciones() { }

        public static int INSERTAR_DETALLES_REPARACION(string reparacionID, string descripcion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_DETALLES_REPARACION", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACION_ID", ReparacionID));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_INICIO", FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_FIN", FechaFin));

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

        public static int BORRAR_DETALLES_REPARACIONES_ID(int detallesReparacionesID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_DETALLES_REPARACIONES_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", detallesReparacionesID));

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

        public static int ACTUALIZAR_DETALLES_REPARACIONES_ID(int ID, string reparacionID, string descripcion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_DETALLES_REPARACIONES_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.Parameters.Add(new SqlParameter("@REPARACION_ID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_FIN", fechaFin));

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