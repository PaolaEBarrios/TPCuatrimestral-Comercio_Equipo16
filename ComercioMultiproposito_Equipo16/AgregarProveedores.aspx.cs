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
            }



        }

        protected void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            string nombre = txtNombreProveedores.Text;

            if (nombre != "")
            {//corregir esto esta mal
                if (negocio.ExisteNombreProveedor(nombre) == false)
                {
                    Proveedor aux = new Proveedor();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.Nombre = nombre;
                    aux.Dni = txtDni.Text;
                    aux.Domicilio = txtDomicilio.Text;
                    aux.Codigo = negocio.TraerUltimoId();
                    aux.Email = txtEmail.Text;
                    aux.Telefono=txtTelefono.Text;

                    negocio.AgregarProveedor(aux);
                    lblAviso.Text = "PROVEEDOR AÑADIDO CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAviso.Text = "EL PROVEEDOR YA EXISTE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAviso.Text = "PROVEEDOR SIN NOMBRE, POR FAVOR INGRESE UNA NOMBRE PARA EL PROVEEDOR";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }



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
                
                aux.Nombre = txtNombreProveedores.Text;
                aux.Dni = txtDni.Text;
                aux.Domicilio = txtDomicilio.Text;
                aux.Codigo =int.Parse( txtid.Text);
                aux.Email = txtEmail.Text;
                aux.Telefono = txtTelefono.Text;

                negocio.ModificarProveedor(aux);
                lblAviso.Text = "PROVEEDOR MODIFICADO CORRECTAMENTE";
                lblAviso.ForeColor = System.Drawing.Color.Green;
            
                //lblAviso.Text = "POR FAVOR CARGUE UN CUIT/CUIL O DNI DEL PROVEEDOR";
                //lblAviso.ForeColor = System.Drawing.Color.Red;
            
        }

        protected void chkBoxProductos_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxProductos.Checked == true)
            {
                chkBoxListProductos.Visible = true;
            }
            else
            {
                chkBoxListProductos.Visible=false;
            }
        }

        protected void chkBoxListProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string valor = chkBoxListProductos.SelectedValue;

            foreach (ListItem item in chkBoxListProductos.Items)
            {
                if (item.Value != valor)
                {
                    item.Selected = false;
                }
            }


            if(valor=="1")
            {
                
            }
            else if(valor=="2")
            {

            }

        }
    }
}