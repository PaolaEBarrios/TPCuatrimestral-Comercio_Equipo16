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
                datos.setearQuery("Select c.id as id, p.dni as dni, p.nombre as nombre,c.fecha as fecha, c.formaPago as formapago from Compras as c inner join Proveedores as p on p.id=c.id_proveedor");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();



                    if (!(datos.Lector["id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["id"];

                    aux.Proveedor = new Proveedor();
                    if (!(datos.Lector["dni"] is DBNull))
                        aux.Proveedor.Dni = (string)datos.Lector["dni"];

                    if (!(datos.Lector["fecha"] is DBNull))
                         aux.FechaCompra = (DateTime)datos.Lector["fecha"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        aux.Proveedor.Nombre = (string)datos.Lector["nombre"];

                    //aux.Producto = new Producto();
                    //if (!(datos.Lector["IdProducto"] is DBNull))
                    //    aux.Producto.Codigo = (int)datos.Lector["IdProducto"];

                    if (!(datos.Lector["formaPago"] is DBNull))
                        aux.FormaPago = (string)datos.Lector["formaPago"];



                    //if (!(datos.Lector["FechaFin"] is DBNull))
                    //    aux.FechaFin = (DateTime)datos.Lector["FechaFin"];

                    //if (!(datos.Lector["TotalCompra"] is DBNull))
                    //    aux.Total = (decimal)datos.Lector["TotalCompra"];

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

        public List<Compra> listaDetalles(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Compra> lista = new List<Compra>();

            try
            {
                datos.setearQuery("select p.nombre as nombre,dc.cantidad as cantidad,dc.precio as precio,dc.Total as subtotal from Compras as c inner join Detalles_Compra as dc on dc.id_compra=c.id inner join productos as p on p.id=dc.id_producto where dc.id_compra = "+ id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();

                    aux.Producto    = new Producto();
                    if (!(datos.Lector["nombre"] is DBNull))
                        aux.Producto.NombreProducto = (string)datos.Lector["nombre"];


                    if (!(datos.Lector["cantidad"] is DBNull))
                        aux.Cantidad = (int)datos.Lector["cantidad"];

                    if (!(datos.Lector["precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["precio"];

                    if (!(datos.Lector["subtotal"] is DBNull))
                        aux.Total = (decimal)datos.Lector["subtotal"];

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

        public Proveedor traerProveedor(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Proveedor aux = new Proveedor();
            try
            {
                datos.setearQuery("Select p.nombre as nombre,p.dni as dni,p.correo as correo,p.telefono  from Compras as c inner join Proveedores as p on p.id=c.id_proveedor where c.id=" + id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        aux.Nombre = (string)datos.Lector["nombre"];
                    }
                    else
                    {
                        aux.Nombre = "";
                    }
                    if (!(datos.Lector["dni"] is DBNull))
                    {
                        aux.Dni = (string)datos.Lector["dni"];
                    }

                    if (!(datos.Lector["correo"] is DBNull))
                    {
                        aux.Email = (string)datos.Lector["correo"];
                    }
                    else
                    {
                        aux.Email = "";
                    }
                    if (!(datos.Lector["telefono"] is DBNull))
                    {
                        aux.Telefono = (string)datos.Lector["telefono"];
                    }
                    else
                    {
                        aux.Telefono = "";
                    }

                    return aux;
                }

                return null;
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

                datos.setearQuery("Select  c.id as Id, c.fecha as FechaCompra,c.formaPago as FormaPago, c.id_Producto as IdProducto, c.id_proveedor as IdProveedor from Compras as c where c.id= @Codigo");
                datos.setParameters("@Codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    compra.Codigo=(int) datos.Lector["Id"];


                    compra.Proveedor = new Proveedor();
                    compra.Proveedor.Codigo = (int)datos.Lector["IdProveedor"];

                    compra.Producto = new Producto(); 
                    compra.Producto.Codigo = (int)datos.Lector["IdProducto"];

                    compra.FormaPago = (string)datos.Lector["FormaPago"];



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

        public void Agregar(Compra aux,List<Producto> listaProducto,List<int> listaCantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            decimal total=calcularTotal(listaProducto, listaCantidad);

            try
            {
                datos.setearQuery("INSERT INTO Compras (id, id_proveedor, fecha, formaPago) VALUES (@id, @idProveedor, @fecha, @formaPago)");
                datos.setParameters("@id", aux.Codigo);
                datos.setParameters("@idProveedor", aux.Proveedor.Codigo);

                datos.setParameters("@fecha", aux.FechaCompra);
                datos.setParameters("@formaPago", aux.FormaPago);



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

        private decimal calcularTotal(List<Producto> listaProducto, List<int> listaCantidad)
        {
            try
            {
                decimal total = 0;

                for (int i = 0; i < listaProducto.Count; i++)
                {
                    Producto producto = listaProducto[i];
                    int cantidad = listaCantidad[i];


                    decimal subtotal = producto.Precio * cantidad;

                    total += subtotal;
                }

                return total;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AgregarDetalles()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public void Modificar(Compra aux, int codigo)
        {
            try
            {

                //me falta modificar el total de la compra
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearQuery("update Compras SET fecha = @FechaCompra, id_proveedor = @IdProveedor,  formaPago = @FormaPago where id = @Codigo");
                    datos.setParameters("@FechaCompra", aux.FechaCompra);

                    datos.setParameters("@IdProveedor", aux.Proveedor.Codigo);

                    datos.setParameters("@FormaPago",aux.FormaPago);
                   // datos.setParameters("@Codigo",aux.Codigo);


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
