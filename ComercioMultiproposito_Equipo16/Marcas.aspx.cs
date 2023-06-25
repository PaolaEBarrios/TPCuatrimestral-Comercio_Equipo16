using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Marcas> articuloList = new List<Marcas>();

            try
            {
                MarcaNegocio negocio = new MarcaNegocio();

                dgvMarcas.DataSource = negocio.listar(); 
                


                dgvMarcas.DataBind();
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id=dgvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarMarca.aspx?id="+id);

        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx");
        }
    }
}