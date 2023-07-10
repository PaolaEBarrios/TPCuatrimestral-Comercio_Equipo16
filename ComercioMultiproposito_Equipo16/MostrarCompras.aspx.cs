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
    public partial class MostrarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CompraNegocio negocio = new CompraNegocio();

                Session.Add("listaCompra", negocio.listar());
                dgvCompras.DataSource = Session["listaCompra"];
                dgvCompras.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IndiceFila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvCompras.DataKeys[IndiceFila].Value.ToString();

                    Response.Redirect("ModificarCompra.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvCompras.DataKeys[IndiceFila].Value.ToString();

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
    }
}