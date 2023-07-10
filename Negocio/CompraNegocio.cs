using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CompraNegocio
    {

        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("select id as ID,id_proveedor as IdProveedor,fecha as FechaCompra, id_producto as IdProducto,formapago as FormaPago,estado as Estado,fechafin as FechaFin from Compras");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();



                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Codigo = (int)datos.Lector["ID"];

                    aux.Proveedor = new Proveedor();
                    if (!(datos.Lector["IdProveedor"] is DBNull))
                        aux.Proveedor.Codigo = (int)datos.Lector["IdProveedor"];

                  ///PENSAR ALGO
                        aux.FechaCompra = (DateTime)datos.Lector["FechaCompra"];

                    aux.Producto = new Producto();
                    if (!(datos.Lector["IdProducto"] is DBNull))
                        aux.Producto.Codigo = (int)datos.Lector["IdProducto"];

                    if (!(datos.Lector["FormaPago"] is DBNull))
                        aux.FormaPago = (string)datos.Lector["FormaPago"];

                    string estadoString = datos.Lector["Estado"].ToString();
                    if (!(datos.Lector["Estado"] is DBNull))
                        aux.Estado = estadoString[0];

                    if (!(datos.Lector["FechaFin"] is DBNull))
                        aux.FechaFin = (DateTime)datos.Lector["FechaFin"];

                    //aux.Producto = new Producto();
                    //if (!(datos.Lector["Nombre"] is DBNull))
                    //    aux.Producto.NombreProducto = (string)datos.Lector["Nombre"];

                    //if (!(datos.Lector["NombreProveedor"] is DBNull))
                    //    aux.Proveedor.Nombre = (string)datos.Lector["NombreProveedor"];
                    
                    //if (!(datos.Lector["Dni"] is DBNull))
                    //    aux.Proveedor.Dni = (string)datos.Lector["Dni"];    

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

        public void Eliminar(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearQuery("delete from Compras where id = @Codigo");
                datos.setParameters("@Codigo", codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
               
            }
        }

        public Compra TraerRegistro(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Compra compra = new Compra();

                datos.setearQuery("Select  c.id as Id,c.estado as Estado,c.FechaFin as FechaFin, c.fecha as FechaCompra,c.formaPago as FormaPago, c.id_Producto as IdProducto, c.id_proveedor as IdProveedor from Compras as c where c.id= @Codigo");
                datos.setParameters("@Codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    compra.Codigo=(int) datos.Lector["Id"];
                    compra.FechaFin = (DateTime)datos.Lector["FechaFin"];

                    compra.Proveedor = new Proveedor();
                    compra.Proveedor.Codigo = (int)datos.Lector["IdProveedor"];

                    compra.Producto = new Producto(); 
                    compra.Producto.Codigo = (int)datos.Lector["IdProducto"];

                    compra.FormaPago = (string)datos.Lector["FormaPago"];

                    string estado = (string)datos.Lector["Estado"];
                    compra.Estado = estado[0];

                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                
                    return compra;
                }
                
                    return null;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select top(1) id from Compras order by id desc");
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

        public void Agregar(Compra aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("insert into Compras (id, id_proveedor, id_Producto, fecha, formaPago, estado, FechaFin) VALUES (" + aux.Codigo + ", " + aux.Proveedor.Codigo + ", " + aux.Producto.Codigo + ", '" + aux.FechaCompra + "', '" + aux.FormaPago + "', '" + aux.Estado + "', '" + aux.FechaFin + "')");
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

        public void Modificar(Compra aux, int codigo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearQuery("update Compras SET fecha = @FechaCompra, id_Producto = @IdProducto, id_proveedor = @IdProveedor, FechaFin = @FechaFin, estado = @Estado, formaPago = @FormaPago where id = @Codigo");
                    datos.setParameters("@FechaCompra", aux.FechaCompra);
                    datos.setParameters("@IdProducto", aux.Producto.Codigo);
                    datos.setParameters("@IdProveedor", aux.Proveedor.Codigo);
                    datos.setParameters("@FechaFin", aux.FechaFin);
                    datos.setParameters("@Estado", aux.Estado);
                    datos.setParameters("@FormaPago",aux.FormaPago);
                    datos.setParameters("@Codigo",aux.Codigo);


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
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
    }
}
