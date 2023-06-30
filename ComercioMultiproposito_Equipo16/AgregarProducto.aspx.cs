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

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;

                //Modificar
                if (!IsPostBack)
                {
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
            }
            else
            {
                //Agregar
                if (!IsPostBack)
                {
                    try
                    {

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        btnModificar.Visible = false;

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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            

            try
            {

                Producto aux = new Producto();

                aux.Codigo =int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;


                MarcaNegocio marcaNegocio = new MarcaNegocio();
                aux.Marca = new Marca();
                string nombre= ddListMarca.SelectedItem.Text;
                aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);
                    
                aux.Ganancia = int.Parse(txtGanancia.Text);
                aux.Stock = int.Parse(txtStock.Text);
                aux.StockMin = int.Parse(txtStockMin.Text);
                aux.Precio = int.Parse(txtPrecio.Text);
                aux.Descripcion = txtDescripcion.Text;

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                aux.Categoria = new Categoria();
                nombre = ddListCategoria.SelectedItem.Text;

                aux.Categoria.Codigo = categoriaNegocio.TraerIDGuardar(nombre);
                
                
                negocio.Agregar(aux);


                lblAviso.Text = "PRODUCTO AÑADIDO CORRECTAMENTE";
                lblAviso.ForeColor = System.Drawing.Color.Green;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {



        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}