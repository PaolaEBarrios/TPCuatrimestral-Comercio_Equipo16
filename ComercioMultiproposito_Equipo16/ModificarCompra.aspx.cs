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
            if (Request.QueryString["id"] != null)
            {
                string codigo = Request.QueryString["id"];
                CompraNegocio compraNegocio = new CompraNegocio();

                if (!IsPostBack)
                {
                    cargarProveedores();
                    cargarMediosDePago();
                    cargarEstado();
                    AccesoDatos datos= new AccesoDatos();
                    Compra compra = new Compra();

                    compra = compraNegocio.TraerRegistro(codigo);

                    if(compra != null)
                    {

                        ddlMediosPago.SelectedItem.Value = compra.FormaPago;
                        ddlProveedores.SelectedItem.Value = compra.Proveedor.Codigo.ToString();

                        string proveedorSeleccionado = ddlProveedores.SelectedItem.Value;

                        ProveedoresNegocio negocio = new ProveedoresNegocio();

                        List<Producto> listaProducto = new List<Producto>();


                        listaProducto = negocio.buscarProductos(proveedorSeleccionado);

                        ddlProductos.Items.Clear();

                        ddlProductos.DataSource = listaProducto;
                        ddlProductos.DataTextField = "NombreProducto";
                        ddlProductos.DataValueField = "Codigo";
                        ddlProductos.DataBind();



                        //ddlProductos.SelectedItem.Text = compra.Producto.Codigo.ToString();
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
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

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            CompraNegocio negocio = new CompraNegocio();
            string id = Request.QueryString["id"];

            ProductoNegocio negocioProduc = new ProductoNegocio();
            
            try
            {
                if (ddlProductos.SelectedItem != null && ddlProductos.SelectedItem.Value != null)
                {
                    string ProductoSeleccionado = ddlProductos.SelectedItem.Value;
                    int cant = int.Parse(txtCantidad.Text);

                    if (cant > 0)
                    {

                        Compra aux = new Compra();
                        CompraNegocio compraNegocio = new CompraNegocio();

                        aux.Codigo = int.Parse(id);

                        aux.FechaCompra = DateTime.Now;

                        aux.Producto = new Producto();
                        aux.Producto.Codigo = int.Parse(ProductoSeleccionado);

                        aux.Proveedor = new Proveedor();
                        aux.Proveedor.Codigo = int.Parse(ddlProveedores.SelectedItem.Value);
                        ///////////////////////////////////anio, mes, dia, hora, min, seg
                         DateTime fechaManual = new DateTime(1753, 1, 1, 00, 00, 00); ;



                        aux.FormaPago = ddlMediosPago.SelectedItem.Text;

                        //modificar stock

                        
                        negocio.Modificar(aux,int.Parse(id));

                        negocioProduc.modificarStock(ProductoSeleccionado, cant);
                        lblAviso.Text = "La compra se modifico con éxito";
                        lblAviso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAviso.Text = "DEBE CARGAR LA CANTIDAD EN LA COMPRA RECUERDE QUE DEBE SER MAYOR A 0";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    lblAviso.Text = "Imposible modificar por favor seleccione un producto";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MostrarCompras.aspx");
        }
    }
}