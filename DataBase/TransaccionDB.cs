using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Clave3_Grupo4.Clases;

namespace Clave3_Grupo4.DataBase
{
    public class TransaccionDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        // Método para insertar un nuevo usuario en la base de datos
        public bool InsertarUsuario(Empleado empleado)
        {
            try
            {
                // SQL para insertar un nuevo usuario
                string query = "INSERT INTO Empleados (Nombre, Apellido, DUI, Rol) VALUES (@Nombre, @Apellido, @DUI, @Rol)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    // Asignación de parámetros
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI);
                    cmd.Parameters.AddWithValue("@Rol", empleado.Rol);

                    // Ejecución del comando
                    int resultado = cmd.ExecuteNonQuery();

                    // Si el comando afectó filas, retorna true
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al insertar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para obtener un usuario por su DUI
        public Empleado ObtenerUsuarioPorDUI(string dui)
        {
            Empleado empleado = null;

            try
            {
                // SQL para obtener un usuario específico
                string query = "SELECT * FROM Empleados WHERE DUI = @DUI";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@DUI", dui);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleado = new Empleado
                            {
                                IdEmpleado = reader.GetInt32("IdEmpleado"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                DUI = reader.GetString("DUI"),
                                Rol = reader.GetString("Rol")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al obtener usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }

            return empleado;
        }

        // Método para actualizar un usuario existente
        public bool ActualizarUsuario(Empleado empleado)
        {
            try
            {
                // SQL para actualizar un usuario existente
                string query = "UPDATE Empleados SET Nombre = @Nombre, Apellido = @Apellido, Rol = @Rol WHERE DUI = @DUI";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    // Asignación de parámetros
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Rol", empleado.Rol);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI);

                    // Ejecución del comando
                    int resultado = cmd.ExecuteNonQuery();

                    // Si el comando afectó filas, retorna true
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al actualizar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para eliminar un usuario por su DUI
        public bool EliminarUsuario(string dui)
        {
            try
            {
                // SQL para eliminar un usuario específico
                string query = "DELETE FROM Empleados WHERE DUI = @DUI";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@DUI", dui);

                    // Ejecución del comando
                    int resultado = cmd.ExecuteNonQuery();

                    // Si el comando afectó filas, retorna true
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }
}

