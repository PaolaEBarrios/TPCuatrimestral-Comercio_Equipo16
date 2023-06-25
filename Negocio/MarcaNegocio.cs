using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select m.id as Id,m.nombre as Nombre from Marcas as m");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();



                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.NombreMarca = (string)datos.Lector["Nombre"];

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


        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select top(1) id from Marcas order by id desc");
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

        public void AgregarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Insert into MARCAS (id, Nombre)  values (" + marca.Codigo + ", '" + marca.NombreMarca + "')");
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

        public void EliminarMarca(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Marcas where id= "+codigo);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool buscarNombreMarca(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select id from Marcas where nombre = '" + nombre + "'");
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

        public string TraerNombreMarca(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                
                datos.setearQuery("select nombre from Marcas where id =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string nombre =(string) datos.Lector["nombre"];
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

    }
}
