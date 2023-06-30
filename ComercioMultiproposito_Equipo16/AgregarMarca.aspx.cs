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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                MarcaNegocio negocio = new MarcaNegocio();

                lblAgregarMarca.Visible = false;
                btnAgregarMarca.Visible=false;

                string nom=Request.QueryString["id"];

                string cadena = negocio.TraerNombreMarca(nom);
                lblModificar.Text +=cadena;
            }
            else
            {
                lblModificar.Visible = false;
                btnModificar.Visible = false;
            }

            

        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            string nombre=txtNombreMarca.Text;

            if(nombre != "")
            {
                if (negocio.ExisteNombreMarca(nombre) == false)
                {
                    Marca aux = new Marca();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.NombreMarca = nombre;

                    negocio.AgregarMarca(aux);
                    lblAviso.Text = "MARCA AÑADIDA CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAviso.Text = "LA MARCA YA EXISTE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAviso.Text = "MARCA SIN NOMBRE, POR FAVOR INGRESE UNA NOMBRE PARA LA MARCA";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            string id = Request.QueryString["id"];

            string nombre = txtNombreMarca.Text;

            if (nombre != "")
            {
                negocio.ModificarMarca(id, nombre);
                lblAviso.Text = "MARCA MODIFICADA CORRECTAMENTE";
                lblAviso.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAviso.Text = "POR FAVOR CARGUE UNA MARCA";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}