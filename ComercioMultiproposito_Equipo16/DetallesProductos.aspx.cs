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
    public partial class DetallesProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = new List<Producto>();

            if(!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);


                        lista = negocio.TraerUnRegistro(id);
                        dgvDetalleProductos.DataSource = lista;
                        dgvDetalleProductos.DataBind();
                    }
                    else
                    {
                        lblAviso.Text = "No hay nada que mostrar si desea ver detalle de un producto seleccione uno en la pagina de productos";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        protected void dgvDetalleProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {
                    
                    string codigo = dgvDetalleProductos.DataKeys[Fila].Value.ToString();

                    Response.Redirect("AgregarProducto.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvDetalleProductos.DataKeys[Fila].Value.ToString();

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
    }
}