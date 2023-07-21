using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ClientesNegocio
    {

        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select p.id as Id,p.nombre as Nombre, p.apellido as Apellido,p.dni as DNI from Clientes as p");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();



                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];



                    if (!(datos.Lector["Apellido"] is DBNull))
                        aux.Apellido = (string)datos.Lector["Apellido"];

                    if (!(datos.Lector["DNI"] is DBNull))
                        aux.Dni = (string)datos.Lector["DNI"];


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

        public int BuscarId(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            int codigo = 0;

            try
            {

                datos.setearQuery("select id as ID from clientes where dni= "+dni);
                datos.ejecutarLectura();

                if(datos.Lector.Read())
                {
                    codigo = (int)datos.Lector["ID"];
                }
                

                return codigo;

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
                datos.setearQuery("select top(1) id from Clientes order by id desc");
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

        public void AgregarCliente(Cliente aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("INSERT INTO Clientes (id, Dni, Telefono, Direccion, Correo, Apellido, CodigoPostal, Nombre) VALUES ("+ aux.Id + ", '" + aux.Dni + "', '" + aux.Telefono + "', '" + aux.Domicilio + "', '"+ aux.Email + "', '" + aux.Apellido + "', '" + aux.Cp + "', '" + aux.Nombre + "')");
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

        public void EliminarCliente(string Id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Clientes where id= " + Id);
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
        public bool ExisteCuitDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select id from Clientes where dni = '" + dni + "'");
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

        public string TraerNombreCliente(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                
                datos.setearQuery("select nombre from Clientes where id =" + id);
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


        public void ModificarCliente(string id, Cliente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("UPDATE Clientes SET nombre = '" + aux.Nombre + "', telefono = '" + aux.Telefono + "', " + "direccion = '" + aux.Domicilio + "', correo = '" + aux.Email + "', apellido = '" + aux.Apellido + "', " + "codigopostal = '" + aux.Cp + "' WHERE id = " + id);
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


        public List<Cliente> TraerUnRegistro(int cod)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("select c.id as id,c.nombre as nombre,c.direccion as domicilio,c.telefono as telefono,c.correo as correo,c.dni as dni,c.apellido as apellido,c.codigoPostal as cp from clientes as c");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();

                    if (cod == (int)datos.Lector["id"])
                    {
                        if (!(datos.Lector["Id"] is DBNull))
                            aux.Id = (int)datos.Lector["Id"];


                        if (!(datos.Lector["nombre"] is DBNull))
                            aux.Nombre = (string)datos.Lector["nombre"];

                        
                        if (!(datos.Lector["domicilio"] is DBNull))
                            aux.Domicilio = (string)datos.Lector["domicilio"];
                        else
                            aux.Domicilio = "Sin Domicilio registrado";

                        if (!(datos.Lector["correo"] is DBNull))
                            aux.Email = (string)datos.Lector["correo"];
                 
                        if (!(datos.Lector["dni"] is DBNull))
                            aux.Dni = (string)datos.Lector["dni"];
                        

                        if (!(datos.Lector["apellido"] is DBNull))
                            aux.Apellido = (string)datos.Lector["apellido"];
                  

                        if (!(datos.Lector["cp"] is DBNull))
                            aux.Cp = (string)datos.Lector["cp"];



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
