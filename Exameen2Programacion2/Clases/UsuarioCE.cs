using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Exameen2Programacion2.Clases
{
    public class UsuarioCE
    {
        //atributos
        private static int Id;
        private static string Correo;
        private static string Clave;
        private static string Nombre;

        //constructor
        public UsuarioCE( string correo, string clave)
        {
            Correo = correo;
            Clave = clave;
        }

        public UsuarioCE()
        {
        }

        //GETTER = funcion que devuelve un valor -- return
        //SETTER = asigna un valor a un atributo -- void -- son metodos

        public int GetId()
        {
            return Id;
        }

        public static string GetCorreo()
        {
            return Correo;
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void SetClave(string clave)
        {
            Nombre = clave;
        }

        public void SetCorreo(string correo)
        {
            Correo = correo;
        }

        public static int ValidarLogin()
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("validarusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            Correo = lectura[0].ToString();

                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

    }
}

