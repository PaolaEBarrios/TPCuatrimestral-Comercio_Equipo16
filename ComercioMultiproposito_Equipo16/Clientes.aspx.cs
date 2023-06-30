using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClientesNegocio negocio = new ClientesNegocio();

                dgvClientes.DataSource = negocio.listar();



                dgvClientes.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvClientes.SelectedDataKey.Value.ToString();


        }

        protected void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            //Response.Redirect("AgregarProveedores.aspx");
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvClientes.DataKeys[rowIndex].Value.ToString();

                    //Response.Redirect("AgregarClientes.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvClientes.DataKeys[rowIndex].Value.ToString();

                    ClientesNegocio negocio = new ClientesNegocio();

                    negocio.EliminarCliente(codigo);

                    Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 
                                                               //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado

                }
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
    }
}