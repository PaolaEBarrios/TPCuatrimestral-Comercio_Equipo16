﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();


                Session.Add("listaCategorias", negocio.listar());

                dgvCategorias.DataSource = Session["listaCategorias"];
                dgvCategorias.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddModCategoria.aspx");
        }

        protected void dgvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int FilaIndice = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Modificar")
                {

                    string codigo = dgvCategorias.DataKeys[FilaIndice].Value.ToString();

                    Response.Redirect("AddModCategoria.aspx?id=" + codigo);

                }
                else if (e.CommandName == "Eliminar")
                {

                    string codigo = dgvCategorias.DataKeys[FilaIndice].Value.ToString();

                    CategoriaNegocio negocio = new CategoriaNegocio();

                    negocio.EliminarCategoria(codigo);

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

        protected void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> lista = (List<Categoria>)Session["listaCategorias"];
            List<Categoria> listaFiltrada = lista.FindAll(x => x.NombreCategoria.ToUpper().Contains(txtBuscarCategoria.Text.ToUpper()));
            dgvCategorias.DataSource = listaFiltrada;
            dgvCategorias.DataBind();
        }
    }
    
}