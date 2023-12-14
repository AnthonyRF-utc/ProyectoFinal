﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exameen2Programacion2
{
    public partial class DetallesReparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }


        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int valor = Clases.DetallesReparaciones.INSERTAR_DETALLES_REPARACION(tRepID.Text, tDes.Text, tFF.Text, tFI.Text);

            if (valor > 0)
            {
                alertas("Detalles agregados con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Detalles");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor = Clases.DetallesReparaciones.BORRAR_DETALLES_REPARACIONES_ID(int.Parse(tID.Text));

            if (valor > 0)
            {
                alertas("Los Detalles fueron borrados con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Detalles");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int valor = Clases.DetallesReparaciones.ACTUALIZAR_DETALLES_REPARACIONES_ID(int.Parse(tID.Text), tRepID.Text, tDes.Text, tFF.Text, tFI.Text);

            if (valor > 0)
            {
                alertas("Los Detalles fueron actualizados con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar Detalles");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(tID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE DetallesReparacionID ='" + ID + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }

            }
        }
    }
}