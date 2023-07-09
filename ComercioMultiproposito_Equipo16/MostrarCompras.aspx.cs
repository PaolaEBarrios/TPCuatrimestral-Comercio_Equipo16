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
    public partial class MostrarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CompraNegocio negocio = new CompraNegocio();

                Session.Add("listaCompra", negocio.listar());
                dgvCompras.DataSource = Session["listaCompra"];
                dgvCompras.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}