using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();

                dgvProductos.DataSource = negocio.listar();



                dgvProductos.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleado.aspx");
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }
    }
}