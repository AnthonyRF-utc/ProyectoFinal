using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exameen2Programacion2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            Clases.UsuarioCE objusuarioCE = new Clases.UsuarioCE(tCorreo.Text, tClave.Text);
            if(Clases.UsuarioCE.ValidarLogin() > 0)
            {
                Response.Redirect("Usuarios.aspx");
            } 
           
        }
    }
}