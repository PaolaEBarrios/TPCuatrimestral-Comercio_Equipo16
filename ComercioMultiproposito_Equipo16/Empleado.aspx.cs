using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdmistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Venta.aspx");
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }
    }
}