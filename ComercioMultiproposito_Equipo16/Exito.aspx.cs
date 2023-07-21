using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = Request.QueryString["nombre"];

            try
            {
                if(nombre != "" || nombre != null)
                {
                    if(nombre == "venta")
                    {
                        lblAviso.Text = "SE REGISTRO LA VENTA EXITOSAMENTE";
                        btnVolver.Text = " Volver a ventas";
                    }
                    else if(nombre == "proveedor")
                    {
                        lblAviso.Text = "SE AGREGO EL PROVEEDOR CON EXITO";
                        btnVolver.Text = "Volver a proveedores";
                    }
                    else if(nombre == "ModificarProducto")
                    {
                        lblAviso.Text = "SE MODIFICO EL PRODUCTO CON EXITO";
                        btnVolver.Text = "Volver a productos";
                    }
                    else
                    {
                        Response.Redirect("Error.aspx");
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
            string nombre = Request.QueryString["nombre"];
            if (nombre == "venta")
            {
                Response.Redirect("Ventas.aspx");
            }
            else if(nombre == "proveedor")
            {
                Response.Redirect("Proveedores.aspx");
            }
            else if(nombre == "ModificarProducto")
            {
                Response.Redirect("Productos.aspx");
            }
            
        }
    }
}