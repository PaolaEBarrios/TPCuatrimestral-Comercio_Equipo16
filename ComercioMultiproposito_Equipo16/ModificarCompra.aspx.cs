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
    public partial class ModificarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProveedores();
                cargarMediosDePago();
                cargarEstado();
            }
        }

        public void cargarEstado()
        {
            ddlEstado.Items.Add("P - PENDIENTE");
            ddlEstado.Items.Add("C - CONCLUIDO");
            ddlEstado.Items.Add("R - RECHAZADO");
        }
        public void cargarMediosDePago()
        {
            ddlMediosPago.Items.Add("Efectivo");
            ddlMediosPago.Items.Add("Tarjeta de credito");
            ddlMediosPago.Items.Add("Tarjeta de debito");
            ddlMediosPago.Items.Add("Transferencia");
            ddlMediosPago.Items.Add("Cheque");
        }

        public void cargarProveedores()
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            List<Proveedor> listaProveedores = new List<Proveedor>();

            listaProveedores = negocio.listar();

            ddlProveedores.DataSource = listaProveedores;
            ddlProveedores.DataTextField = "Nombre";
            ddlProveedores.DataValueField = "Codigo";
            ddlProveedores.DataBind();

        }
        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}