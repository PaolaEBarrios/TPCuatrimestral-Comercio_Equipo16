using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select p.id as Id,p.nombre as Producto,m.nombre as Marca,c.nombre as Categoria,p.precio as Precio from Productos as p left join marcas as m on m.id=p.id_marca left join Categorias as c on c.id=p.id_categoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();



                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["Id"];


                    if (!(datos.Lector["Producto"] is DBNull))
                        aux.NombreProducto = (string)datos.Lector["Producto"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.NombreMarca = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.NombreMarca = "Sin Marca";

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.NombreCategoria = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.NombreCategoria = "Sin categoria";

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];


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


        public bool confirmarStock(string codigo, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            bool BanderaStock= false;

            try
            {
                datos.setearQuery("SELECT stock_actual FROM Productos WHERE id = @codigo");
                datos.setParameters("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int Stock = Convert.ToInt32(datos.Lector["stock_actual"]);
                    
                    if(Stock >= cantidad)
                    {
                        BanderaStock = true;
                    }
                     
                }

                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return BanderaStock;
        }
        public void EliminarProducto(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Productos where id= " + codigo);
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


        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select top(1) id from Productos order by id desc");
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

        public void modificarStock(string codigo,int cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Productos set stock_actual+= " + cant + " where id =" + codigo);
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
        public void Agregar(Producto aux)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO Productos (Id, Nombre, id_marca, Ganancia, Stock_actual, Stock_minimo, Precio, Descripcion, id_categoria) VALUES ";
                consulta += "(" + aux.Codigo + ", '" + aux.NombreProducto + "', " + aux.Marca.Codigo + ", " + aux.Ganancia + ", " + aux.Stock + ", " + aux.StockMin + ", " + aux.Precio + ", '" + aux.Descripcion + "', " + aux.Categoria.Codigo + ")";

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


        public void Modificar(Producto aux)
        {
            AccesoDatos datos = new AccesoDatos();

            

            try
            {
                string precio = aux.Precio.ToString();
                precio=precio.Replace(",", ".");
                

                string consulta = "UPDATE Productos SET ";
                consulta += "Nombre = '" + aux.NombreProducto + "', ";
                consulta += "id_marca = " + aux.Marca.Codigo + ", ";
                consulta += "Ganancia = " + aux.Ganancia + ", ";
                consulta += "Stock_actual = " + aux.Stock + ", ";
                consulta += "Stock_minimo = " + aux.StockMin + ", ";
                consulta += "Precio = " + precio + ", ";
                consulta += "Descripcion = '" + aux.Descripcion + "', ";
                consulta += "id_categoria = " + aux.Categoria.Codigo + " ";
                consulta += "WHERE Id = " + aux.Codigo;

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


        public List<Producto>TraerUnRegistro(int cod)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select p.id as Id,p.nombre as Producto,m.nombre as Marca, m.id as idMarca ,c.nombre as Categoria, c.id as idCategoria,p.precio as Precio, ganancia as Ganancia, stock_actual as Stock,stock_minimo as StockMinimo,descripcion as Descripcion from Productos as p left join marcas as m on m.id=p.id_marca left join Categorias as c on c.id=p.id_categoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    if (cod == (int)datos.Lector["id"])
                    {
                        if (!(datos.Lector["Id"] is DBNull))
                            aux.Codigo = (int)datos.Lector["Id"];


                        if (!(datos.Lector["Producto"] is DBNull))
                            aux.NombreProducto = (string)datos.Lector["Producto"];

                        aux.Marca = new Marca();
                        if (!(datos.Lector["Marca"] is DBNull))
                            aux.Marca.NombreMarca = (string)datos.Lector["Marca"];
                        else
                            aux.Marca.NombreMarca = "Sin Marca";

                        if (!(datos.Lector["idMarca"] is DBNull))
                            aux.Marca.Codigo = (int)datos.Lector["idMarca"];
                        //chequear que hacer si no pasa
                        aux.Categoria = new Categoria();
                        if (!(datos.Lector["Categoria"] is DBNull))
                            aux.Categoria.NombreCategoria = (string)datos.Lector["Categoria"];
                        else
                            aux.Categoria.NombreCategoria = "Sin categoria";

                        if (!(datos.Lector["Categoria"] is DBNull))
                            aux.Categoria.Codigo = (int)datos.Lector["idCategoria"];
                        //chequear que hacer si no pasa

                        if (!(datos.Lector["Precio"] is DBNull))
                            aux.Precio = (decimal)datos.Lector["Precio"];

                        if (!(datos.Lector["Ganancia"] is DBNull))
                            aux.Ganancia = (int)datos.Lector["Ganancia"];
                        //lo mismo

                        if (!(datos.Lector["Stock"] is DBNull))
                            aux.Stock = (int)datos.Lector["Stock"];
                        //lo mismo

                        if (!(datos.Lector["StockMinimo"] is DBNull))
                            aux.StockMin = (int)datos.Lector["StockMinimo"];
                        //lo mismo

                        if (!(datos.Lector["Descripcion"] is DBNull))
                            aux.Descripcion = (string)datos.Lector["Descripcion"];

                        //lo mismo

                        lista.Add(aux);
                        return lista;
                    }
                    
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

    }



}
