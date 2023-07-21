using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {

        public List<Venta> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Venta> lista = new List<Venta>();
            
            try
            {

                datos.setearQuery("Select v.id as IDventa,c.dni as dni,c.apellido as apellido,v.fecha as Fecha from Ventas as v inner join Clientes as c on c.id = v.id_cliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();

                    if (!(datos.Lector["IDventa"] is DBNull))
                        aux.codigo = (int)datos.Lector["IDventa"];


                    aux.cliente = new Cliente();
                    if (!(datos.Lector["dni"] is DBNull))
                        aux.cliente.Dni = (string)datos.Lector["dni"];

                    if (!(datos.Lector["Fecha"] is DBNull))
                        aux.fechaVenta = (DateTime)datos.Lector["Fecha"];

                    if (!(datos.Lector["apellido"] is DBNull))
                        aux.cliente.Apellido = (string)datos.Lector["apellido"];
                    
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

        public List<Venta> listaDetalles(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Venta> lista = new List<Venta>();

            try
            {
                datos.setearQuery("select p.nombre as producto,dv.cantidad as cantidad,dv.precio as precio,dv.total as subtotal from Detalles_Venta as dv inner join Ventas as v on v.id = dv.id_venta inner join Productos as p on dv.id_producto = p.id where dv.id_venta = " +id);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Venta aux = new Venta();

                    aux.producto = new Producto();
                    if (!(datos.Lector["producto"] is DBNull))
                        aux.producto.NombreProducto = (string)datos.Lector["producto"];

        
                    if (!(datos.Lector["cantidad"] is DBNull))
                        aux.cantidad = (int)datos.Lector["cantidad"];

                    if (!(datos.Lector["precio"] is DBNull))
                        aux.precioUnidad = (decimal)datos.Lector["precio"];

                    if (!(datos.Lector["subtotal"] is DBNull))
                        aux.total = (decimal)datos.Lector["subtotal"];

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
        public Cliente traerCliente(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente aux = new Cliente();
            try
            {
                datos.setearQuery("select c.apellido as apellido,c.nombre as nombre,c.dni as dni, c.telefono as telefono, c.correo as email from Clientes as c inner join Ventas as v on v.id_cliente = c.id where v.id = "+id);
                datos.ejecutarLectura();

                if(datos.Lector.Read())
                {
                    if (!(datos.Lector["apellido"]is DBNull))
                    {
                        aux.Apellido = (string)datos.Lector["apellido"];
                    }
                    else
                    {
                        aux.Apellido = "";
                    }
                    if(!(datos.Lector["nombre"] is DBNull))
                    {
                        aux.Nombre = (string)datos.Lector["nombre"];
                    }
                    
                    if(!(datos.Lector["dni"] is DBNull))
                    {
                        aux.Dni = (string)datos.Lector["dni"];
                    }
                    if (!(datos.Lector["email"] is DBNull))
                    {
                        aux.Email = (string)datos.Lector["email"];
                    }
                    else
                    {
                        aux.Email = "";
                    }

                    if (!(datos.Lector["telefono"] is DBNull))
                        aux.Telefono = (string)datos.Lector["telefono"];
                    else
                        aux.Telefono = "";
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

        public bool ModificarStock(List<int> listaCantidad, List<Producto> listaProductos)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("UPDATE Productos SET stock_actual = stock_actual - @cantDescontar WHERE Id = @id");

                for (int i = 0; i < listaProductos.Count; i++)
                {
                    int cantDescontar = listaCantidad[i];
                    int idProducto = listaProductos[i].Codigo;

                    datos.setParameters("@cantidadDescontar", cantDescontar);
                    datos.setParameters("@idProducto", idProducto);

                    datos.ejecutarAccion();
                }

                return true;
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

        public void EliminarDetalles(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("delete from Detalles_venta where id_venta= " + codigo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Agregar(Venta aux,List<Producto> listaProducto, List<int> listaCantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                int cod = traerUltimoId();
                //CREATE TABLE Ventas(
                //  id INT PRIMARY KEY,
                //  id_cliente INT,
                //  fecha DATE,
                //  FOREIGN KEY(id_cliente) REFERENCES Clientes(id)
                //)
                string consulta = "insert into ventas(id,id_cliente,fecha) values";
                consulta += "("+ cod + "," +aux.cliente.Id + ",'" + aux.fechaVenta.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                datos.setearQuery(consulta);
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

        public void Eliminar(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("delete from ventas where id = " + codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AgregarDetalles(Venta aux, List<Producto> listaProducto, List<int> listaCantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                //CREATE TABLE Detalles_Venta( --Productos Vendidos-- -
                //  id_venta INT,
                //  id_producto INT,
                //  cantidad I NT,
                //  precio money,
                //  total  money,
                //  FOREIGN KEY(id_venta) REFERENCES Ventas(id),
                //  FOREIGN KEY(id_producto) REFERENCES Productos(id)
                //)

                string consulta = "INSERT INTO Detalles_Venta (id_venta, id_producto, cantidad, precio, total) VALUES ";
    
                //CUANDO CARGO EL PRECIO TIENE QUE SER EL PRECIO DE LA VENTA

                for (int i = 0; i < listaProducto.Count; i++)
                {
                    string precio = listaProducto[i].Precio.ToString();
                    precio = precio.Replace(",", ".");

                    decimal tot = (listaProducto[i].Precio * listaCantidad[i]);
                    string total = tot.ToString();
                    total = total.Replace(",", ".");

                    consulta += "(" + aux.codigo + ", " + listaProducto[i].Codigo + ", " + listaCantidad[i] + ", " +
                        precio + ", " + total + ")";

                    if (i < listaProducto.Count - 1)
                        consulta += ",";
                }

                datos.setearQuery(consulta);
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
        public int traerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int cont = 0;
                datos.setearQuery("select top(1) id from Ventas order by id desc");
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
    }
}
