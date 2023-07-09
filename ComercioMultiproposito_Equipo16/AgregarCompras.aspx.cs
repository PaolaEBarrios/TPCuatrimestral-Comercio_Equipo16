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
    public partial class AgregarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarProveedores();
                cargarMediosDePago();
                cargarEstado();
            }
            
        }

        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proveedorSeleccionado = ddlProveedores.SelectedItem.Value;

            ProveedoresNegocio negocio = new ProveedoresNegocio();

            List<Producto> listaProducto = new List<Producto>(); 
            

            listaProducto = negocio.buscarProductos(proveedorSeleccionado);

            ddlProductos.Items.Clear();

            ddlProductos.DataSource = listaProducto;
            ddlProductos.DataTextField = "NombreProducto";
            ddlProductos.DataValueField = "Codigo";
            ddlProductos.DataBind();


        }

        public void cargarEstado()
        {
            
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

            listaProveedores=negocio.listar();

            ddlProveedores.DataSource = listaProveedores;
            ddlProveedores.DataTextField = "Nombre"; 
            ddlProveedores.DataValueField = "Codigo"; 
            ddlProveedores.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}