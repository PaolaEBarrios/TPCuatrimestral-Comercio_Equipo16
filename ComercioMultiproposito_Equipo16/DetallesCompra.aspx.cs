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
    public partial class DetallesCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                cargarDatos();
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }

        private void cargarDatos()
        {
            try
            {
                lblIDcompra.Text = Request.QueryString["id"];

                CompraNegocio negocio = new CompraNegocio();
                Proveedor aux = new Proveedor();

                aux = negocio.traerProveedor(lblIDcompra.Text);

                lblNombre.Text = aux.Nombre;
                lbldni.Text = aux.Dni;
                lblEmail.Text = aux.Email;
                lblTelefono.Text = aux.Telefono;

                List<Compra> listacompra = new List<Compra>();
                listacompra= negocio.listaDetalles(lblIDcompra.Text);
                decimal total = 0;
                int i = 0;

                foreach (Compra compra in listacompra)
                {
                    total += listacompra[i].Total;
                    i++;
                }

                lblTotalCompra.Text = total.ToString();

                dgvDetalles.DataSource = listacompra;
                dgvDetalles.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MostrarCompras.aspx");
        }
    }
}