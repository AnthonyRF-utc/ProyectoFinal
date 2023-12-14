
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Exameen2Programacion2.Clases

{
    public class Usuarios
    {
        public static int UsuarioID { get; set; }
        public static string Nombre { get; set; }
        public static string CorreoElectronico { get; set; }
        public static string Telefono { get; set; }

        public Usuarios(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }
        public Usuarios() { }

        public static int INSERTAR_USUARIO(string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", CorreoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", Telefono));


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
        public static int BORRAR_USUARIOS_ID(int UsuarioID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_USUARIOS_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", UsuarioID));

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
        public static int ACTUALIZAR_USUARIO_ID(int ID, string nombre, string CorreoElectronico, int telefono)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_USUARIO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", CorreoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

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

