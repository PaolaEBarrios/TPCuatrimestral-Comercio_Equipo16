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
                if (Session["listProductosCompra"] == null)
                {
                    Session["listProductosCompra"] = new List<Producto>();
                }

                if (Session["listCantidadCompra"] == null)
                {
                    Session["listCantidadCompra"] = new List<int>();
                }

                cargarProveedores();
                cargarMediosDePago();

                if (Session["proveedorSeleccionado"] != null)
                {
                    string proveedorSeleccionado = Session["proveedorSeleccionado"].ToString();
                    ddlProveedores.SelectedValue = proveedorSeleccionado;
                    ddlProveedores.Enabled = false; 
                }

                // Cargar los productos para el proveedor seleccionado
                ddlProveedores_SelectedIndexChanged(sender, e);
            }
            
        }
        protected void ChkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkProveedor.Checked == true)
            {
                Session["proveedorSeleccionado"] = null;
                ddlProveedores.Enabled = true;

            }
        }
        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            

                string proveedorSeleccionado = ddlProveedores.SelectedItem.Value;

                if (Session["proveedorSeleccionado"] == null)
                {
                    ProveedoresNegocio negocio = new ProveedoresNegocio();
                    List<Producto> listaProducto = new List<Producto>();

                    listaProducto = negocio.buscarProductos(proveedorSeleccionado);

                    ddlProductos.Items.Clear();
                    ddlProductos.DataSource = listaProducto;
                    ddlProductos.DataTextField = "NombreProducto";
                    ddlProductos.DataValueField = "Codigo";
                    ddlProductos.DataBind();
                }

                Session["proveedorSeleccionado"] = proveedorSeleccionado;
                ddlProveedores.SelectedValue = proveedorSeleccionado;


                ddlProveedores.Enabled = false;
                ChkProveedor.Checked = false;

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
                        
                        aux.Proveedor = new Proveedor();
                        aux.Proveedor.Codigo = int.Parse(ddlProveedores.SelectedItem.Value);
                        


                        aux.FormaPago = ddlMediosPago.SelectedItem.Text;

                        
                        //falta sacar el total de la compra 


                        //ahora detalles de compra


                        //asignarle
                        List<Producto> listaProductosCompra = (List<Producto>)Session["listProductosCompra"];
                        List<int> listaCantidadCompra = (List<int>)Session["listCantidadCompra"];

                        compraNegocio.Agregar(aux,listaProductosCompra,listaCantidadCompra);
                        
                        //modificar stock
                        negocio.modificarStock(ProductoSeleccionado, cant);
                        negocio.AgregarDetalles(aux,listaProductosCompra,listaCantidadCompra);


                        lblAviso.Text = "Compra registrada con éxito";
                        lblAviso.ForeColor = System.Drawing.Color.Green;

                        Session["listProductosCompra"] = null;
                        Session["listCantidadCompra"] = null;

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

        protected void btnAgregarMasProductos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProductos.SelectedItem != null)
                {

                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto aux = new Producto();

                    string codigo = ddlProductos.SelectedValue;

                    aux = negocio.traerProducto(codigo);

                    //chequear si el producto existe en detalles compra

                    bool Bandera = false;
                    List<Producto> listaProductos = (List<Producto>)Session["listProductosCompra"];

                    if(listaProductos != null)
                    {
                        foreach (Producto producto in listaProductos)
                        {
                            if (producto.Codigo.ToString() == codigo)
                            {
                                Bandera = true;
                                break;
                            }
                        }

                    }

                    if (!Bandera)
                    {
                        if (txtCantidad.Text != "")
                        {
                            int cant = int.Parse(txtCantidad.Text);

                            //List<Producto> listaProductos = (List<Producto>)Session["listaProductos"];
                            List<int> listaCantidad = (List<int>)Session["listCantidadCompra"];



                            listaProductos.Add(aux);
                            listaCantidad.Add(cant);


                            Session["listaProductosCompra"] = listaProductos;
                            Session["listaCantidadCompra"] = listaCantidad;


                        }
                        else
                        {
                            lblAviso.Text = "Por favor ingrese una cantidad para el producto";
                            txtCantidad.BorderColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblAviso.Text = "El producto ya fue añadido a la venta";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }
                            

                }
                else
                {

                        
                }
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


    }
}