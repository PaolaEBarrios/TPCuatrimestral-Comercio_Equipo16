using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();

                //dgvProveedores.DataSource = negocio.listar();
                //dgvProveedores.DataBind();

                Session.Add("listaProveedores", negocio.listar());
                dgvProveedores.DataSource = Session["listaProveedores"];
                dgvProveedores.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void dgvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvProveedores.SelectedDataKey.Value.ToString();


        }

        protected void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProveedores.aspx");
        }

        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvProveedores.DataKeys[rowIndex].Value.ToString();

                    Response.Redirect("AgregarProveedores.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvProveedores.DataKeys[rowIndex].Value.ToString();

                    ProveedoresNegocio negocio = new ProveedoresNegocio();

                    negocio.EliminarProveedor(codigo);

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

        protected void txtBuscarProveedores_TextChanged(object sender, EventArgs e)
        {
            List<Proveedor> lista = (List<Proveedor>)Session["listaProveedores"];
            List<Proveedor> listaFiltrada = lista.FindAll(x => x.Dni.ToUpper().Contains(txtBuscarProveedores.Text.ToUpper()));
            dgvProveedores.DataSource = listaFiltrada;
            dgvProveedores.DataBind();
        }
    }
}