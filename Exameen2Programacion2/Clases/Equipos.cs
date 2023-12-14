
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Exameen2Programacion2.Clases

{
    public class Equipos
    {
        public int EquipoID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int UsuarioID { get; set; }

        public Equipos(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            EquipoID = equipoID;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            UsuarioID = usuarioID;
        }

        public Equipos() { }

        public static int INSERTAR_EQUIPO(string tipoEquipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_EQUIPO", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));


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
        public static int BORRAR_EQUIPO_ID(int EquipoID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_EQUIPO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", EquipoID));

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
        public static int ACTUALIZAR_EQUIPO_ID(string tipoEquipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EQUIPO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));

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


