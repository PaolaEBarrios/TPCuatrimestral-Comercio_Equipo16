using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ProveedoresNegocio
    {

        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select p.id as Id,p.nombre as Nombre from Proveedores as p");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();



                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];

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
                datos.setearQuery("select top(1) id from Proveedores order by id desc");
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

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Insert into Proveedores (id, Nombre)  values (" + proveedor.Codigo + ", '" + proveedor.Nombre + "')");
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

        public void EliminarProveedor(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Proveedor where id= "+codigo);
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
        public bool ExisteNombreProveedor(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select id from Proveedores where nombre = '" + nombre + "'");
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

        public string TraerNombreProveedor(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                
                datos.setearQuery("select nombre from Proveedores where id =" + id);
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


        public void ModificarProveedor(string id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Proveedores set nombre = '" + nombre + "' where id = " + id);
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

    }
}
