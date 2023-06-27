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
    public partial class AddModCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                lblAgregarCategoria.Visible = false;
                btnAgregarCategoria.Visible = false;

                string nom = Request.QueryString["id"];

                string cadena = negocio.TraerNombreCategoria(nom);
                lblModificarCategoria.Text += "";
                lblModificarCategoria.Text += cadena;
            }
            else
            {
                lblModificarCategoria.Visible = false;
                btnModificarCategoria.Visible = false;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            string nombre = txtNombreCategoria.Text;

            if(nombre != "")
            {
                if (negocio.ExisteNombreCategoria(nombre) == false)
                {
                    Categoria aux = new Categoria();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.NombreCategoria = nombre;

                    negocio.AgregarCategoria(aux);
                    lblAviso.Text = "CATEGORIA AÑADIDA CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAviso.Text = "LA CATEGORIA YA EXISTE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAviso.Text = "CATEGORIA SIN NOMBRE POR FAVOR CARGUE UN NOMBRE";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
                

        }

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            string id=Request.QueryString["id"];

            string nombre = txtNombreCategoria.Text;
            
            if(nombre != "")
            {
                negocio.ModificarCategoria(id, nombre);
                lblAviso.Text = "CATEGORIA MODIFICADA CORRECTAMENTE";
                lblAviso.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAviso.Text = "POR FAVOR CARGUE UNA CATEGORIA";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }
    }
}