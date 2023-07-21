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
    public partial class AgregarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["id"] != null)
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();

                lblAgregarProveedores.Visible = false;
                btnAgregarProveedores.Visible = false;

                string id = Request.QueryString["id"];

                if(!IsPostBack)
                {
                    Session.Add("listaProveedor", negocio.listar());
                    List<Proveedor> lista = (List<Proveedor>)Session["listaProveedor"];

                    foreach (Proveedor proveedor in lista)
                    {
                        if (id == proveedor.Codigo.ToString())
                        {
                            txtid.Text = proveedor.Codigo.ToString();
                            txtDni.Text = proveedor.Dni.ToString();
                            txtDomicilio.Text = proveedor.Domicilio.ToString();
                            txtEmail.Text = proveedor.Email.ToString();
                            txtNombreProveedores.Text = proveedor.Nombre.ToString();
                            txtTelefono.Text = proveedor.Telefono.ToString();
                            
                        }
                    }


                    string cadena = negocio.TraerNombreProveedor(id);
                    lblModificar.Text += cadena;
                }
                
            }
            else
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();

                Session.Add("listaProveedores", negocio.listar());
                lblModificar.Visible = false;
                btnModificar.Visible = false;
                
                if(!IsPostBack)
                {
                    if (Session["listaIDproductos"] == null)
                    {
                        Session["listaIDproductos"] = new List<int>();
                    }
                }
            
            }



        }

        protected void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            string dni = txtDni.Text;

            if (dni != "")
            {
                if (negocio.ExisteDniProveedor(dni) == false)
                {
                    Proveedor aux = new Proveedor();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.Nombre = txtNombreProveedores.Text;
                    if(txtNombreProveedores.Text != "")
                    {
                        aux.Dni = txtDni.Text;
                        aux.Domicilio = txtDomicilio.Text;

                        aux.Email = txtEmail.Text;
                        aux.Telefono = txtTelefono.Text;

                        if (txtEmail.Text != "" || txtTelefono.Text != "")
                        {
                            

                            if (Session["listaIDproductos"] != null)
                            {

                                List<int> listaProd = (List<int>)Session["listaIDproductos"];
                                

                                negocio.AgregarProductosProveedor(listaProd,aux.Codigo);
                                negocio.AgregarProveedor(aux);

                                lblAviso.Text = "PROVEEDOR AÑADIDO CORRECTAMENTE";
                                lblAviso.ForeColor = System.Drawing.Color.Green;

                                string nombre = "proveedor";
                                Response.Redirect("Exito.aspx?nombre="+nombre);
                            
                            }

                        }
                        else
                        {
                            lblAviso.Text = "POR FAVOR AGREGUE UN CONTACTO (EMAIL O TELEFONO)";
                            lblAviso.ForeColor = System.Drawing.Color.Red;
                            txtTelefono.BorderColor = System.Drawing.Color.Red;
                            txtEmail.BorderColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblAviso.Text = "POR FAVOR AGREGUE UN NOMBRE";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                        txtNombreProveedores.BorderColor = System.Drawing.Color.Red;
                        
                    }
                   
                }
                else
                {
                    lblAviso.Text = "EL PROVEEDOR YA EXISTE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;

                }
            }
            else
            {
                lblAviso.Text = "PROVEEDOR SIN CUIT/DNI/CUIL, IMPOSIBLE AÑADIR";
                lblAviso.ForeColor = System.Drawing.Color.Red;
                txtDni.BorderColor = System.Drawing.Color.Red;
            }



        }

        private void cargarDdl()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            btnModificar.Visible = false;
            lblModificar.Visible = false;



            ddListMarca.DataSource = marcaNegocio.listar();
            ddListMarca.DataBind();
            ddListCategoria.DataSource = categoriaNegocio.listar();
            ddListCategoria.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            Proveedor aux = new Proveedor();
            string id = Request.QueryString["id"];

            string dni = txtDni.Text;

            

                aux.Dni = txtDni.Text;
            if(txtDni.Text != "")
            {
                aux.Nombre = txtNombreProveedores.Text;

                if(txtNombreProveedores.Text != "")
                {
                    aux.Dni = txtDni.Text;
                    aux.Domicilio = txtDomicilio.Text;
                    aux.Codigo = int.Parse(txtid.Text);
                    aux.Email = txtEmail.Text;
                    aux.Telefono = txtTelefono.Text;

                    if (txtTelefono.Text != "" || txtEmail.Text != "")
                    {
                        negocio.ModificarProveedor(aux);
                        lblAviso.Text = "PROVEEDOR MODIFICADO CORRECTAMENTE";
                        lblAviso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAviso.Text = "POR FAVOR CARGUE UN CONTACTO EMAIL O TELEFONO";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                        txtEmail.BorderColor = System.Drawing.Color.Red;
                        txtTelefono.BorderColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblAviso.Text = "POR FAVOR CARGUE UN NOMBRE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                    txtNombreProveedores.BorderColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblAviso.Text = "POR FAVOR CARGUE UN CUIT/CUIL O DNI DEL PROVEEDOR";
                lblAviso.ForeColor = System.Drawing.Color.Red;
                txtDni.BorderColor = System.Drawing.Color.Red;
            }



        }

        protected void chkBoxProductos_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxProductos.Checked == true)
            {
                btnExiste.Visible = true;
                btnNuevo.Visible = true;

            }
            else
            {
                btnExiste.Visible = false;
                btnNuevo.Visible = false;
                FormularioEnFalso();
                dgvProductos.Visible = false;
            }
        }



        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if(e.CommandName == "Seleccionar")
                {


                    //terminar

                   List<int>listaidproducto=(List<int>)Session["listaIDproductos"];

                    listaidproducto.Add(Fila);

                    Session["listaIDproductos"] = listaidproducto;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();


            try
            {

                Producto aux = new Producto();
                txtCodigo.Text = negocio.TraerUltimoId().ToString();
                aux.Codigo = int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;

                if (txtProducto.Text != "")
                {

                    

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    aux.Marca = new Marca();
                    string nombre = ddListMarca.SelectedItem.Text;
                    aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);

                    if (txtGanancia.Text != "")
                    {
                        aux.Ganancia = int.Parse(txtGanancia.Text);
                    }
                    else
                    {
                        aux.Ganancia = 0;
                    }

                    if (txtStock.Text != "")
                    {
                        aux.Stock = int.Parse(txtStock.Text);
                    }
                    else
                    {
                        aux.Stock = 0;
                    }

                    if (txtStockMin.Text != "")
                    {
                        aux.StockMin = int.Parse(txtStockMin.Text);
                    }
                    else
                    {
                        aux.StockMin = 0;
                    }
                    if (txtPrecio.Text != "")
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


                        List<int> listProd = (List<int>)Session["listaIDproductos"];

                        listProd.Add(int.Parse(txtCodigo.Text));

                        Session["listaIDproductos"] = listProd;

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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormularioEnVerdadero();

                cargarDdl();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnExiste_Click(object sender, EventArgs e)
        {
            try
            {

                FormularioEnFalso();

                dgvProductos.Visible = true;

                ProductoNegocio negocio = new ProductoNegocio();

                Session.Add("listaProductos", negocio.listar());
                dgvProductos.DataSource = Session["listaProductos"];
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        private void FormularioEnFalso()
        {
            lblCodigo.Visible = false;

            txtCodigo.Visible = false;

            lblMarca.Visible = false;

            lblnombreproducto.Visible = false;

            txtProducto.Visible = false;

            ddListMarca.Visible = false;


            lblCategoria.Visible = false;

            ddListCategoria.Visible = false;

            lblPrecio.Visible = false;

            txtPrecio.Visible = false;

            lblGanancia.Visible = false;

            txtGanancia.Visible = false;

            lblStock.Visible = false;

            txtStock.Visible = false;

            lblStockMin.Visible = false;

            txtStockMin.Visible = false;

            lblDescripcion.Visible = false;

            txtDescripcion.Visible = false;

            btnAgregar.Visible = false;
        }


        private void FormularioEnVerdadero()
        {
            lblCodigo.Visible = true;

            txtCodigo.Visible = true;

            lblMarca.Visible = true;

            lblnombreproducto.Visible = true;

            txtProducto.Visible = true;

            ddListMarca.Visible = true;


            lblCategoria.Visible = true;

            ddListCategoria.Visible = true;

            lblPrecio.Visible = true;

            txtPrecio.Visible = true;

            lblGanancia.Visible = true;

            txtGanancia.Visible = true;

            lblStock.Visible = true;

            txtStock.Visible = true;

            lblStockMin.Visible = true;

            txtStockMin.Visible = true;

            lblDescripcion.Visible = true;

            txtDescripcion.Visible = true;

            btnAgregar.Visible = true;
        }


        protected void dgvProductos_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int Fila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Seleccionar")
                {

                    string codigo = dgvProductos.DataKeys[Fila].Value.ToString();

                    
                    ///AGREGAR EL CODIGO A UNA SESION DE CODIGOS DE PRODUCTOS 
                    ///QUE CUANDO SE REGISTRE EL PROVEEDOR, DAR DE ALTA JUNTO CON EL CODIGO PROVEEDOR
                    ///EN LA TABLA DE PROVEEDORES_PRODUCTOS

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }    
            
                
        }
    }
}