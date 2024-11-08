using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clave3_Grupo4.Clases;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Clave3_Grupo4.DataBase
{
    public class EmpleadoDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        // Método para insertar un nuevo empleado en la base de datos
        public bool InsertarEmpleado(Empleado empleado)
        {
            try
            {
                string query = "INSERT INTO Empleados (Nombre, Apellido, DUI, Rol) VALUES (@Nombre, @Apellido, @DUI, @Rol)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI);
                    cmd.Parameters.AddWithValue("@Rol", empleado.Rol);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para obtener un empleado por su ID
        public Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            Empleado empleado = null;
            try
            {
                string query = "SELECT * FROM Empleados WHERE IdEmpleado = @IdEmpleado";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

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

                MessageBox.Show("Error al obtener empleado" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conexionDB.CerrarConexion();
            }
            return empleado;
        }

        // Método para obtener todos los empleados de la base de datos
        public DataTable ObtenerTodosEmpleados()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = "SELECT * FROM Empleados";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
            return dataTable;
        }

        // Método para actualizar un empleado en la base de datos
        public bool ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                string query = "UPDATE Empleados SET Nombre = @Nombre, Apellido = @Apellido, DUI = @DUI, Rol = @Rol WHERE IdEmpleado = @IdEmpleado";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI);
                    cmd.Parameters.AddWithValue("@Rol", empleado.Rol);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para eliminar un empleado por su ID
        public bool EliminarEmpleado(int idEmpleado)
        {
            try
            {
                string query = "DELETE FROM Empleados WHERE IdEmpleado = @IdEmpleado";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        public DataTable BuscarEmpleados(string criterio)
        {
            DataTable dataTable = new DataTable();

            try
            {
                string query = "SELECT * FROM Empleados WHERE Nombre LIKE @Criterio OR Apellido LIKE @Criterio";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }

            return dataTable;
        }
    }
}
