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

                if (e.CommandName =="Detalle")
                {
                    string codigo = dgvCompras.DataKeys[IndiceFila].Value.ToString();

                    Response.Redirect("DetallesCompra.aspx?id=" + codigo);
                }

                //if (e.CommandName == "Modificar")
                //{

                //    string codigo = dgvCompras.DataKeys[IndiceFila].Value.ToString();

                //    Response.Redirect("ModificarCompra.aspx?id=" + codigo);

                //}
                //else if (e.CommandName == "Eliminar")
                //{

                //    string codigo = dgvCompras.DataKeys[IndiceFila].Value.ToString();

                //    CompraNegocio negocio = new CompraNegocio();

                //    negocio.Eliminar(codigo);

                //    Response.Redirect(Request.Url.AbsoluteUri);
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Compra> lista = (List<Compra>)Session["listaCompra"];
                List<Compra> listaFiltrada = lista.FindAll(x => x.Codigo == int.Parse(txtBuscar.Text));
                dgvCompras.DataSource = listaFiltrada;
                dgvCompras.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}