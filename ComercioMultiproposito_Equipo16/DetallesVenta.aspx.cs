using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class DetallesVenta : System.Web.UI.Page
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

                VentaNegocio negocio = new VentaNegocio();
                Cliente aux = new Cliente();

                aux = negocio.traerCliente(lblIDcompra.Text);

                lblApellidoNombre.Text = aux.Apellido + " " + aux.Nombre;
                lbldni.Text = aux.Dni;
                lblEmail.Text = aux.Email;
                lblTelefono.Text = aux.Telefono;

                List<Venta> listaventas = new List<Venta>();
                listaventas = negocio.listaDetalles(lblIDcompra.Text);
                decimal total = 0;
                int i = 0;

                foreach (Venta venta in listaventas)
                {
                    total += listaventas[i].total;
                    i++;
                }

                lblTotalVenta.Text = total.ToString();
                
                dgvDetalles.DataSource = listaventas;
                dgvDetalles.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MostrarVentas.aspx");
        }
    }
}