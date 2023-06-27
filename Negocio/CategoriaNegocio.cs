using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select c.id as Id,c.nombre as Nombre from Categorias as c");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();



                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.NombreCategoria = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarCategoria(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Categorias where id= " + codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public string TraerNombreCategoria(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearQuery("select nombre from Categorias where id =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string nombre = (string)datos.Lector["nombre"];
                    return nombre;
                }

                return "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public bool ExisteNombreCategoria(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select id from Categorias where nombre = '" + nombre + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select top(1) id from Categorias order by id desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cont = (int)datos.Lector["id"];
                }

                return cont + 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Insert into Categorias (id, Nombre)  values (" + categoria.Codigo + ", '" + categoria.NombreCategoria + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarCategoria(string id,string nombre)
        {
            AccesoDatos datos=new AccesoDatos();
            try
            {
                datos.setearQuery("update Categorias set nombre = '" + nombre + "' where id = " + id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                datos.cerrarConexion();
            }
        }
    }
   

}
