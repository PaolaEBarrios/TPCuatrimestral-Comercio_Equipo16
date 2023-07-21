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
    public partial class MostrarVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarDatos();
            }
        }


        private void cargarDatos()
        {
            try
            {
                VentaNegocio negocio = new VentaNegocio();
                //dgvProductos.DataSource = negocio.listar();

                Session.Add("listaVentas", negocio.listar());
                dgvVentas.DataSource = Session["listaVentas"];
                dgvVentas.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {

                if(e.CommandName == "Detalle")
                {
                    string codigo = dgvVentas.DataKeys[Fila].Value.ToString();
                    Response.Redirect("DetallesVenta.aspx?id="+codigo);
                }

                //if (e.CommandName == "Modificar")
                //{

                //    string codigo = dgvVentas.DataKeys[Fila].Value.ToString();

                //    Response.Redirect("ModificarVentas.aspx?id=" + codigo);

                //}
                //else if (e.CommandName == "Eliminar")
                //{

                //    string codigo = dgvVentas.DataKeys[Fila].Value.ToString();

                //    VentaNegocio negocio = new VentaNegocio();

                //    negocio.Eliminar(codigo);
                //    negocio.EliminarDetalles(codigo);
                //    //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado!!!!!!
                //    Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 


                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Venta> lista = (List<Venta>)Session["listaVentas"];
                List<Venta> listaFiltrada = lista.FindAll(x => x.codigo == int.Parse(txtBuscar.Text));
                dgvVentas.DataSource = listaFiltrada;
                dgvVentas.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}