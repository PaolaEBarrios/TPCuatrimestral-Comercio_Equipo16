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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            if (Session["id"] != null && Session["Tipo"] != null)
            {
                btnVolver.Visible = false;
            }


            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;
                lblAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"]);

                List<Producto> listProductos = new List<Producto>();

                listProductos = negocio.TraerUnRegistro(id);
                if(!IsPostBack)
                {
                    

                    if (Session["id"] != null && Session["tipo"] != null)
                    {
                        int cod = (int)Session["id"];
                        string tipo = Session["tipo"].ToString();

                        btnVolver.Visible = false;

                        Session.Remove("id");
                        Session.Remove("tipo");
                    }
                    else
                    {
                        txtCodigo.Text = listProductos[0].Codigo.ToString();
                        txtDescripcion.Text = listProductos[0].Descripcion;
                        txtGanancia.Text = listProductos[0].Ganancia.ToString();
                        txtPrecio.Text = listProductos[0].Precio.ToString();

                        txtProducto.Text = listProductos[0].NombreProducto;
                        txtStock.Text = listProductos[0].Stock.ToString();
                        txtStockMin.Text = listProductos[0].StockMin.ToString();
                    }

                }

                //Modificar

                try
                {

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        ddListMarca.DataSource = marcaNegocio.listar();
                        ddListMarca.DataBind();
                        ddListCategoria.DataSource = categoriaNegocio.listar();
                        ddListCategoria.DataBind();


                }
                catch (Exception ex)
                {

                        throw ex;
                }
                
            }
            else
            {
                //Agregar
               
                    try
                    {

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        btnModificar.Visible = false;
                        lblModificar.Visible = false;    

                        int cod = negocio.TraerUltimoId();
                        txtCodigo.Text = cod.ToString();

                        ddListMarca.DataSource = marcaNegocio.listar();
                        ddListMarca.DataBind();
                        ddListCategoria.DataSource = categoriaNegocio.listar();
                        ddListCategoria.DataBind();


                    }

                    catch (Exception ex)
                    {

                        throw ex;
                    }

                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            

            try
            {

                Producto aux = new Producto();
                            
                aux.Codigo =int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;

                if (txtProducto.Text != "")
                {
                    


                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    aux.Marca = new Marca();
                    string nombre = ddListMarca.SelectedItem.Text;
                    aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);

                    if(txtGanancia.Text != "")
                    {
                        aux.Ganancia = int.Parse(txtGanancia.Text);
                    }
                    else
                    {
                        aux.Ganancia = 0;
                    }
                    
                    if(txtStock.Text != "")
                    {
                        aux.Stock = int.Parse(txtStock.Text);
                    }
                    else
                    {
                        aux.Stock = 0;
                    }

                    if(txtStockMin.Text != "")
                    {
                        aux.StockMin = int.Parse(txtStockMin.Text);
                    }
                    else
                    {
                        aux.StockMin = 0;
                    }
                    if(txtPrecio.Text != "")
                    {
                        aux.Precio = int.Parse(txtPrecio.Text);
                    }
                    else
                    {
                        aux.Precio = 0;
                    }
                    

                    if (txtDescripcion.Text != "")
                    {
                        aux.Descripcion = txtDescripcion.Text;
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        aux.Categoria = new Categoria();
                        nombre = ddListCategoria.SelectedItem.Text;

                        aux.Categoria.Codigo = categoriaNegocio.TraerIDGuardar(nombre);


                        negocio.Agregar(aux);


                        lblAviso.Text = "PRODUCTO AÑADIDO CORRECTAMENTE";
                        lblAviso.ForeColor = System.Drawing.Color.Green;

                        
                    }
                    else
                    {
                        lblAviso.Text = "Por favor cargue una descripcion";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }

                    
                }
                else
                {
                    lblAviso.Text = "Por favor ingrese un nombre al producto";
                    txtProducto.BackColor = System.Drawing.Color.Red;
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();


            try
            {


                Producto aux = new Producto();

                aux.Codigo = int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;

                if((txtProducto.Text!= ""))
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    aux.Marca = new Marca();
                    string nombre = ddListMarca.SelectedItem.Text;
                    aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);

                    if(txtGanancia.Text != "")
                    {
                        aux.Ganancia = int.Parse(txtGanancia.Text);
                    }
                    else
                    {
                        aux.Ganancia = 0;
                    }
                    if(txtStock.Text != "")
                    {
                        aux.Stock = int.Parse(txtStock.Text);
                    }
                    else
                    {
                        aux.Stock = 0;
                    }

                    if(txtStockMin.Text != "")
                    {
                        aux.StockMin = int.Parse(txtStockMin.Text);
                    }
                    else
                    {
                        aux.StockMin= 0;
                    }
                    if(txtPrecio.Text != "")
                    {
                        aux.Precio = decimal.Parse(txtPrecio.Text);
                    }
                    else
                    {
                        aux.Precio = 0;
                    }

                    if(txtDescripcion.Text != "")
                    {
                        aux.Descripcion = txtDescripcion.Text;


                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        aux.Categoria = new Categoria();
                        nombre = ddListCategoria.SelectedItem.Text;

                        aux.Categoria.Codigo = categoriaNegocio.TraerIDGuardar(nombre);


                        negocio.Modificar(aux);

                        string cat = "ModificarProducto";
                        Response.Redirect("Exito.aspx?nombre=" +cat);

                    }
                    else
                    {
                        lblAviso.Text = "POR FAVOR CARGUE LA DESCRIPCION PARA MODIFICAR";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    lblAviso.Text = "Por favor ingrese un nombre al producto";
                    txtProducto.BackColor = System.Drawing.Color.Red;
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
            Response.Redirect("Productos.aspx");
        }
    }
}