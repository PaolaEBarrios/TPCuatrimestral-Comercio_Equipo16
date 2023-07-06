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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx");
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IndiceFila = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvMarcas.DataKeys[IndiceFila].Value.ToString();

                    Response.Redirect("AgregarMarca.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvMarcas.DataKeys[IndiceFila].Value.ToString();

                    MarcaNegocio negocio = new MarcaNegocio();

                    negocio.EliminarMarca(codigo);

                    Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 
                                                               //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void btnEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleado.aspx");
        }

        protected void txtBuscarMarca_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.NombreMarca.ToUpper().Contains(txtBuscarMarca.Text.ToUpper()));
            dgvMarcas.DataSource = listaFiltrada;
            dgvMarcas.DataBind();
        }
    }
}