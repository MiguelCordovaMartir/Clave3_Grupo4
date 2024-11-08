using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave3_Grupo4.Clases;
using Clave3_Grupo4.DataBase;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clave3_Grupo4.Interfaces
{
    public partial class EmpleadosForm : Form
    {
        private EmpleadoDB empleadoDB;
        public EmpleadosForm()
        {
            InitializeComponent();
            empleadoDB = new EmpleadoDB();
            CargarRolComboBox();
            CargarEmpleadosEnGrid();

            // Asociar el evento CellClick del DataGridView
            dataGridViewEmpleados.CellClick += dataGridViewEmpleados_CellClick;
        }
        // Método para cargar los roles en el ComboBox
        private void CargarRolComboBox()
        {
            cmbRol.Items.AddRange(new string[]
            {
                "Cajero",
                "Asesor",
                "AtencionCliente",
                "Gerente"
            });
        }

        // Método para cargar los datos de empleados en el DataGridView
        private void CargarEmpleadosEnGrid()
        {
            DataTable dataTable = empleadoDB.ObtenerTodosEmpleados();
            dataGridViewEmpleados.DataSource = dataTable;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDUI.Clear();
            cmbRol.SelectedIndex = -1;
        }


        private bool ValidarCampos()
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDUI.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de solo letras en Nombre y Apellido
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El Nombre y Apellido solo deben contener letras", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de formato del DUI: 8 dígitos, un guion y un dígito (Ej: 12345678-9)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDUI.Text, @"^\d{8}-\d$"))
            {
                MessageBox.Show("El DUI debe tener el formato 12345678-9.", "Formato de DUI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Empleado empleado = new Empleado
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                Rol = cmbRol.SelectedItem.ToString()
            };

            if (empleadoDB.InsertarEmpleado(empleado))
            {
                MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleadosEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
            Empleado empleado = new Empleado
            {
                IdEmpleado = idEmpleado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                Rol = cmbRol.SelectedItem.ToString()
            };

            if (empleadoDB.ActualizarEmpleado(empleado))
            {
                MessageBox.Show("Empleado modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleadosEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este empleado?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                if (empleadoDB.EliminarEmpleado(idEmpleado))
                {
                    MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEmpleadosEnGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Evento CellClick para cargar los datos en los controles al seleccionar un empleado
        }

        private void dataGridViewEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Tiene que selecionar un empleado
            {
                DataGridViewRow filaSeleccionada = dataGridViewEmpleados.Rows[e.RowIndex];

                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtDUI.Text = filaSeleccionada.Cells["DUI"].Value.ToString();
                cmbRol.SelectedItem = filaSeleccionada.Cells["Rol"].Value.ToString();
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(criterio))
            {
                DataTable dataTable = empleadoDB.BuscarEmpleados(criterio);
                dataGridViewEmpleados.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron empleados con el criterio especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnObtenerClientes_Click(object sender, EventArgs e)
        {
            CargarEmpleadosEnGrid();
            txtBuscar.Clear();
            LimpiarCampos();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear una nueva aplicación de Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // Obtener la hoja activa en el archivo Excel
                Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;

                // Añadir encabezados de columnas
                for (int i = 0; i < dataGridViewEmpleados.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridViewEmpleados.Columns[i].HeaderText;
                }

                // Añadir los datos de cada fila
                for (int i = 0; i < dataGridViewEmpleados.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewEmpleados.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewEmpleados.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Mostrar Excel y liberar el objeto
                excelApp.Visible = true;
                MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
