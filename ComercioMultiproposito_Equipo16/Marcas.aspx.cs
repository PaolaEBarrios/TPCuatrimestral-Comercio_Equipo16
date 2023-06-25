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


        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx");
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            

            if (e.CommandName == "Modificar")
            {

                string codigo = dgvMarcas.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("AgregarMarca.aspx?id=" + codigo);
            
            }
            else if(e.CommandName == "Eliminar")
            {

                string codigo = dgvMarcas.DataKeys[rowIndex].Value.ToString();//el codigo no es el de la row

                MarcaNegocio negocio = new MarcaNegocio();

                negocio.EliminarMarca(codigo);
                
                Response.Redirect(Request.Url.AbsoluteUri);//redirige a la misma pagina 
                //falta que al eliminar se confirme o se cancele y al eliminar agregue un cartel de eliminado

            }
        
        }

    }
}