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

                string nom = Request.QueryString["id"];

                string cadena = negocio.TraerNombreProveedor(nom);
                lblModificar.Text += cadena;
            }
            else
            {
                lblModificar.Visible = false;
                btnModificar.Visible = false;
            }



        }

        protected void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            string nombre = txtNombreProveedores.Text;

            if (nombre != "")
            {
                if (negocio.ExisteNombreProveedor(nombre) == false)
                {
                    Proveedor aux = new Proveedor();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.Nombre = nombre;

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
            string id = Request.QueryString["id"];

            string nombre = txtNombreProveedores.Text;

            if (nombre != "")
            {
                negocio.ModificarProveedor(id, nombre);
                lblAviso.Text = "PROVEEDOR MODIFICADO CORRECTAMENTE";
                lblAviso.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAviso.Text = "POR FAVOR CARGUE UN PROVEEDOR";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}