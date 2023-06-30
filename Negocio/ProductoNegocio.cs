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

    }



}
