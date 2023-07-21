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
    public partial class AgregarVentas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            if (!IsPostBack)
            {
                
                if (Session["ListaProductos"] == null)
                {
                    Session["ListaProductos"] = new List<Producto>();
                }

                if (Session["ListaCantidad"] == null)
                {
                    Session["ListaCantidad"] = new List<int>();
                }
                if (Session["listaPrecios"] ==null)
                {
                    Session["listaPrecios"]= new List<decimal>();
                }

                VentaNegocio negocio = new VentaNegocio();
                txtCodigoVenta.Text = negocio.traerUltimoId().ToString();
                cargarDll();
            }
            else
            {
                
            }
            //CREATE TABLE Ventas(
            //id INT PRIMARY KEY,
            //id_cliente INT,
            //fecha DATE,
            //FOREIGN KEY(id_cliente) REFERENCES Clientes(id)
            //)
            //Go


            //CREATE TABLE Detalles_Venta( --Productos Vendidos-- -
            //  id_venta INT,
            //  id_producto INT,
            //  cantidad INT,
            //  precio DECIMAL(10, 2),
            //  FOREIGN KEY(id_venta) REFERENCES Ventas(id),
            //  FOREIGN KEY(id_producto) REFERENCES Productos(id)
            //)


        }

        public void cargarDll()
        {
            List<Producto> listaProducto = new List<Producto>();

            ProductoNegocio negocio = new ProductoNegocio();

            listaProducto = negocio.listar();

            ddlProductos.Items.Clear();

            ddlProductos.DataSource = listaProducto;
            ddlProductos.DataTextField = "NombreProducto";
            ddlProductos.DataValueField = "Codigo";
            ddlProductos.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtDni.Text != "")
                {
                    ClientesNegocio clientesNegocio = new ClientesNegocio();
                    if (clientesNegocio.ExisteCuitDni(txtDni.Text))
                    {
                        Venta venta = new Venta();


                        venta.cliente = new Cliente();

                        venta.cliente.Dni = txtDni.Text;

                        venta.cliente.Id = clientesNegocio.BuscarId(txtDni.Text);

                        venta.codigo = int.Parse(txtCodigoVenta.Text);
                        venta.fechaVenta = DateTime.Now;



                        venta.cantidad = int.Parse(txtCantidad.Text);
                        venta.precioFinal = decimal.Parse(txtPrecioImpuestos.Text);
                        venta.total = decimal.Parse(txtTotalxProducto.Text);

                        VentaNegocio negocio = new VentaNegocio();


                        //CREATE TABLE Detalles_Venta(--Productos Vendidos-- -
                        //id_venta INT,
                        //id_producto INT,
                        //cantidad INT,
                        //precio DECIMAL(10, 2),
                        //FOREIGN KEY(id_venta) REFERENCES Ventas(id),
                        //FOREIGN KEY(id_producto) REFERENCES Productos(id)

                        List<Producto> listaProductos = (List<Producto>)Session["ListaProductos"];
                        List<int> listaCantidad = (List<int>)Session["ListaCantidad"];
                        List<decimal> listaPreciosGanancia = (List<decimal>)Session["listaPrecios"];


                        bool bandera=negocio.ModificarStock(listaCantidad,listaProductos);

                        if(bandera != false)
                        {
                            negocio.Agregar(venta, listaProductos, listaCantidad);
                            negocio.AgregarDetalles(venta, listaProductos, listaCantidad);
                            string nombre = "venta";
                            Response.Redirect("Exito.aspx?nombre=" + nombre);
                        }
                        else
                        {
                            lblAviso.Text = "IMPOSIBLE AÑADIR, NO HAY SUFICIENTE STOCK";
                            lblAviso.ForeColor = System.Drawing.Color.Red;
                        }
                        
                       
                    }
                    else
                    {
                        txtDni.BorderColor = System.Drawing.Color.Red;
                        lblAviso.Text = "EL DNI DE CLIENTE NO EXISTE, ERROR INGRESE UN CLIENTE VALIDO";
                        lblAviso.ForeColor = System.Drawing.Color.Red;  
                    }
                }
                else
                {

                    txtDni.BorderColor = System.Drawing.Color.Red;
                    lblAviso.Text = "Por favor, se necesita asociar un cliente a la venta.";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private decimal CalcularTotalVenta(List<int> listaCantidad,List<decimal>listaprecios)
        {
            try
            {

                decimal acumulador = 0;

                for (int i = 0; i < listaprecios.Count; i++)
                {
                    decimal totalxProducto = listaprecios[i] * listaCantidad[i];
                    acumulador += totalxProducto;
                }

                return acumulador;


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

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaProducto = new List<Producto>();

            listaProducto = negocio.listar();
            string productoSeleccionado = ddlProductos.SelectedValue;
            lblPrecioGanancia.Text = " Precio con ganancia del: % ";

            try
            {
                Producto producto = listaProducto.Find(p => p.Codigo.ToString() == productoSeleccionado);

                txtPrecio.Text = producto.Precio.ToString();
                decimal resultado = (decimal)(producto.Ganancia) / 100 * producto.Precio;


                txtPrecioImpuestos.Text = (producto.Precio + resultado).ToString();
                lblPrecioGanancia.Text= String.Concat(lblPrecioGanancia.Text,producto.Ganancia.ToString());

                txtCodigoVenta.Text = producto.Codigo.ToString();

                txtCantidad.Text = "";
                txtTotalxProducto.Text = "";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            decimal resultado = 0;
            try
            {
                resultado = decimal.Parse(txtPrecioImpuestos.Text) * decimal.Parse(txtCantidad.Text);
                txtTotalxProducto.Text = resultado.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnMasProductos_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlProductos.SelectedItem != null)
                {

                    
                    

                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto aux = new Producto();

                    string codigo = ddlProductos.SelectedValue;

                    aux = negocio.traerProducto(codigo);

                    bool Bandera = false;

                    foreach (ListItem item in lboxProductos.Items)
                    {
                        if (item.Value == codigo)
                        {
                            Bandera = true;
                            break;
                        }
                    }

                    if (!Bandera)
                    {



                        if(txtCantidad.Text != "")
                        {
                            int cant = int.Parse(txtCantidad.Text);


                            // Obtener las listas de las variables de sesión
                            List<Producto> listaProductos = (List<Producto>)Session["ListaProductos"];
                            List<int> listaCantidad = (List<int>)Session["ListaCantidad"];
                            List<decimal> listaPrecios = (List<decimal>)Session["listaPrecios"];
                            

                            listaProductos.Add(aux);


                            decimal precio =decimal.Parse(txtPrecioImpuestos.Text);
                            listaPrecios.Add(precio);

                            lboxProductos.Items.Add(new ListItem(aux.NombreProducto, aux.Codigo.ToString()));

                            decimal tot=Decimal.Parse(txtCantidad.Text) *decimal.Parse( txtPrecioImpuestos.Text);
                            string totalidad = tot.ToString();

                            string procant = aux.NombreProducto +" Cantidad: "+ cant.ToString() +"  $"+totalidad ;
                            lboxCantidades.Items.Add(procant);

                            listaCantidad.Add(cant);


                            decimal totalventa = CalcularTotalVenta(listaCantidad, listaPrecios);

                            txtTotalVenta.Text = totalventa.ToString();

                            // Guardar las listas 
                            Session["listaPrecios"] = listaPrecios;
                            Session["ListaProductos"] = listaProductos;
                            Session["ListaCantidad"] = listaCantidad;

                            
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
                    lblAviso.Text = "POR FAVOR SELECCIONE UN PRODUCTO";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}