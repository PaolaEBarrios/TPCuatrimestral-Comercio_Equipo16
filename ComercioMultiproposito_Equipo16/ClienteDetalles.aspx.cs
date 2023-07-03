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
    public partial class ClienteDetalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientesNegocio negocio = new ClientesNegocio();
            List<Cliente> lista = new List<Cliente>();

            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);


                        lista = negocio.TraerUnRegistro(id);
                        dgvClienteDetalle.DataSource = lista;
                        dgvClienteDetalle.DataBind();
                    }
                    else
                    {
                        lblAviso.Text = "No hay nada que mostrar si desea ver detalle de un producto seleccione uno en la pagina de Clientes.aspx";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void dgvClienteDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvClienteDetalle.DataKeys[Fila].Value.ToString();

                    Response.Redirect("AgregarClientes.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvClienteDetalle.DataKeys[Fila].Value.ToString();

                    ClientesNegocio negocio = new ClientesNegocio();

                    negocio.EliminarCliente(codigo);
                    //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado!!!!!!
                    Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
    }
}