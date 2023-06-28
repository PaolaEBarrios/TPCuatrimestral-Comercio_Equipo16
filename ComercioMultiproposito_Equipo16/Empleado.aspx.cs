using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace ComercioMultiproposito_Equipo16
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sesionActiva(Session["usuario"]))
                Response.Redirect("Login.aspx", false);
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
            Response.Redirect("Compra.aspx");
        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }

        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}