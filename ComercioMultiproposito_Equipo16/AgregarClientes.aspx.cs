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
    public partial class AgregarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ClientesNegocio negocio = new ClientesNegocio();

                lblAgregarClientes.Visible = false;
                btnAgregarClientes.Visible = false;

                string nom = Request.QueryString["id"];

                string cadena = negocio.TraerNombreCliente(nom);
                lblModificarClientes.Text += cadena;
            }
            else
            {
                lblModificarClientes.Visible = false;
                btnModificarClientes.Visible = false;
            }



        }

        protected void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            ClientesNegocio negocio = new ClientesNegocio();
            string dni = txtDni.Text;

            if (dni != "")
            {
                if (negocio.ExisteCuitDni(dni) == false)
                {
                    Cliente aux = new Cliente();

                    aux.Id = negocio.TraerUltimoId();
                    aux.Dni=dni;
                    

                    
                    if(txtTelefono.Text != "" || txtEmail.Text != "")
                    {
                        aux.Contacto = new Contacto();

                        aux.Contacto.telefono = txtTelefono.Text;
                        aux.Contacto.domicilio = txtDomicilio.Text;
                        aux.Contacto.email = txtEmail.Text;
                        aux.Apellido = txtApellido.Text;
                        aux.Contacto.cp = txtCP.Text;

                        if(txtNombreClientes.Text != "")
                        {
                            aux.Nombre = txtNombreClientes.Text;

                            negocio.AgregarCliente(aux);
                            lblAvisoClientes.Text = "CLIENTE AÑADIDO CORRECTAMENTE";
                            lblAvisoClientes.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblAvisoClientes.Text = "POR FAVOR AÑADA UN NOMBRE";
                            lblAvisoClientes.ForeColor = System.Drawing.Color.Red;
                            txtNombreClientes.BackColor = System.Drawing.Color.Red;
                        }

                        
                    }
                    else
                    {
                        txtEmail.BackColor = System.Drawing.Color.Red;
                        txtTelefono.BackColor = System.Drawing.Color.Red;
                        lblAvisoClientes.Text = "POR FAVOR AGREGAR UN CONTACTO: EMAIL O TELEFONO CELULAR";
                        lblAvisoClientes.ForeColor = System.Drawing.Color.Red;
                    }
                    
                }
                else
                {
                    lblAvisoClientes.Text = "EL CLIENTE YA EXISTE";
                    lblAvisoClientes.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAvisoClientes.Text = "CLIENTE SIN DNI O CUIT, POR FAVOR INGRESE UN DNI O CUIT PARA EL CLIENTE";
                lblAvisoClientes.ForeColor = System.Drawing.Color.Red;
            }



        }

        protected void btnVolverClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void btnModificarClientes_Click(object sender, EventArgs e)
        {
            ClientesNegocio negocio = new ClientesNegocio();
            string id = Request.QueryString["id"];

            string nombre = txtNombreClientes.Text;

            if (nombre != "")
            {
                negocio.ModificarCliente(id, nombre);
                lblAvisoClientes.Text = "CLIENTE MODIFICADO CORRECTAMENTE";
                lblAvisoClientes.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAvisoClientes.Text = "POR FAVOR CARGUE UN CLIENTE";
                lblAvisoClientes.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}