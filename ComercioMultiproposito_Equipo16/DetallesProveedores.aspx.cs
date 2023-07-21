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
    public partial class DetallesProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();
                List<Proveedor> listaProveedor=new List<Proveedor>();

                if (!IsPostBack)
                {
                    try
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            int id = int.Parse(Request.QueryString["id"]);


                            listaProveedor.Add(negocio.TraerRegistro(id));



                            dgvDetalleProductos.DataSource = listaProveedor;
                            dgvDetalleProductos.DataBind();
                        }
                        else
                        {
                            lblAviso.Text = "No hay nada que mostrar si desea ver detalle de un PROVEEDOR seleccione uno en la pagina de productos";
                            lblAviso.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    }


}