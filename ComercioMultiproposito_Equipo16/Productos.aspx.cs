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
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvProductos.DataKeys[Fila].Value.ToString();

                    Response.Redirect("AgregarProducto.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvProductos.DataKeys[Fila].Value.ToString();

                    ProductoNegocio negocio = new ProductoNegocio();

                    negocio.EliminarProducto(codigo);
                    //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado!!!!!!
                    Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 
                                                              

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }
    }
}