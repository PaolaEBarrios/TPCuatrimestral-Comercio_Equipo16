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
                lblAgregarMarca.Visible = false;
                btnAgregarMarca.Visible=false;
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


            if (negocio.buscarNombreMarca(nombre) == false)
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }
    }
}