using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Clave3_Grupo4.Clases;
using System.Windows.Forms;

namespace Clave3_Grupo4.DataBase
{
    public class ClienteDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        // Método para insertar un nuevo cliente en la base de datos
        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                // SQL de inserción
                string query = "INSERT INTO Clientes (Nombre, Apellido, DUI, TipoProducto, BilleteraVirtual) VALUES (@Nombre, @Apellido, @DUI, @TipoProducto, @BilleteraVirtual)";

                // Establecer la conexión y preparar el comando
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", cliente.DUI);
                    cmd.Parameters.AddWithValue("@TipoProducto", cliente.TipoProducto);
                    cmd.Parameters.AddWithValue("@BilleteraVirtual", cliente.BilleteraVirtual);

                    // Ejecutar el comando y verificar si se insertó correctamente
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al insertar cliente" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para obtener un cliente por su ID
        public Cliente ObtenerClientePorId(int idCliente)
        {
            Cliente cliente = null;
            try
            {
                // SQL de selección
                string query = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";

                // Establecer la conexión y preparar el comando
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Verificar si se encontró el cliente y llenar los datos
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                IdCliente = reader.GetInt32("IdCliente"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                DUI = reader.GetString("DUI"),
                                TipoProducto = reader.GetString("TipoProducto"),
                                BilleteraVirtual = reader.GetDecimal("BilleteraVirtual")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al obtener cliente" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
            return cliente;
        }

        // Método para actualizar un cliente en la base de datos
        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                // SQL de actualización
                string query = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, DUI = @DUI, TipoProducto = @TipoProducto, BilleteraVirtual = @BilleteraVirtual WHERE IdCliente = @IdCliente";

                // Establecer la conexión y preparar el comando
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", cliente.DUI);
                    cmd.Parameters.AddWithValue("@TipoProducto", cliente.TipoProducto);
                    cmd.Parameters.AddWithValue("@BilleteraVirtual", cliente.BilleteraVirtual);

                    // Ejecutar el comando y verificar si se actualizó correctamente
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al actualizar cliente" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para eliminar un cliente por su ID
        public bool EliminarCliente(int idCliente)
        {
            try
            {
                // SQL de eliminación
                string query = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

                // Establecer la conexión y preparar el comando
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    // Ejecutar el comando y verificar si se eliminó correctamente
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al eliminar cliente" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }
}
