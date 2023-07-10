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

            listaProveedores=negocio.listar();

            ddlProveedores.DataSource = listaProveedores;
            ddlProveedores.DataTextField = "Nombre"; 
            ddlProveedores.DataValueField = "Codigo"; 
            ddlProveedores.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            


            //if(negocio.confirmarStock(ProductoSeleccionado,cant))
            //{

            //}
            //else
            //{

            //}ESTO ES PARA VENTA MENSA
            try
            {
                if(ddlProductos.SelectedItem != null && ddlProductos.SelectedItem.Value != null)
                {
                    string ProductoSeleccionado = ddlProductos.SelectedItem.Value;
                    int cant = int.Parse(txtCantidad.Text);

                    if (cant > 0)
                    {

                        Compra aux = new Compra();
                        CompraNegocio compraNegocio = new CompraNegocio();

                        aux.Codigo = compraNegocio.TraerUltimoId();

                        aux.FechaCompra = DateTime.Now;

                        aux.Producto = new Producto();
                        aux.Producto.Codigo = int.Parse(ProductoSeleccionado);

                        aux.Proveedor = new Proveedor();
                        aux.Proveedor.Codigo = int.Parse(ddlProveedores.SelectedItem.Value);
                        
                        aux.FechaFin = default(DateTime);

                        string estado = ddlEstado.SelectedItem.Text;
                        aux.Estado = estado[0];

                        aux.FormaPago = ddlMediosPago.SelectedItem.Text;

                        compraNegocio.Agregar(aux);
                        //modificar stock

                        negocio.modificarStock(ProductoSeleccionado, cant);



                        lblAviso.Text = "Compra registrada con éxito";
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
                    lblAviso.Text = "Imposible agregar por favor seleccione un producto";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            



        }
    }
}