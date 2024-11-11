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

namespace Clave3_Grupo4.Interfaces
{
    public partial class TransaccionesForm : Form
    {
        private TransaccionDB transaccionDB = new TransaccionDB();
        private ClienteDB clienteDB = new ClienteDB();
        private EmpleadoDB empleadoDB = new EmpleadoDB();
        public TransaccionesForm()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            CargarClientes();
            CargarEmpleados();
            CargarTipoTransaccion();
            LimpiarCamposTransaccion();
        }


        // Configura los ComboBox para que solo permitan selección
        private void ConfigurarComboBoxes()
        {
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleados.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoTransaccion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Carga la lista de clientes en el ComboBox
        private void CargarClientes()
        {
            DataTable clientes = clienteDB.ObtenerTodosClientes(); // Obtener los clientes como DataTable
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "Nombre"; // Asegúrate de que sea el campo correcto en la tabla Clientes
            cmbClientes.ValueMember = "IdCliente";
        }

        private void CargarEmpleados()
        {
            DataTable empleados = empleadoDB.ObtenerTodosEmpleados(); // Obtener los empleados como DataTable
            cmbEmpleados.DataSource = empleados;
            cmbEmpleados.DisplayMember = "Nombre"; // Asegúrate de que sea el campo correcto en la tabla Empleados
            cmbEmpleados.ValueMember = "IdEmpleado";
        }
        // Configura el ComboBox de tipo de transacción
        private void CargarTipoTransaccion()
        {
            cmbTipoTransaccion.Items.AddRange(new string[] { "Abono", "Cargo" });
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, el punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear cualquier otro carácter
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposTransaccion()) return;

            Transaccion transaccion = new Transaccion
            {
                IdCliente = Convert.ToInt32(cmbClientes.SelectedValue),
                IdEmpleado = cmbEmpleados.SelectedValue != null ? (int?)Convert.ToInt32(cmbEmpleados.SelectedValue) : null,
                TipoTransaccion = cmbTipoTransaccion.SelectedItem.ToString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                Descripcion = txtDescripcion.Text
            };

            if (transaccionDB.InsertarTransaccion(transaccion))
            {
                MessageBox.Show("Transacción agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialTransacciones();
                LimpiarCamposTransaccion();
            }
            else
            {
                MessageBox.Show("Error al agregar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCamposTransaccion()
        {
            if (cmbClientes.SelectedItem == null || cmbTipoTransaccion.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out _))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios correctamente.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Limpiar campos del formulario
        private void LimpiarCamposTransaccion()
        {
            cmbClientes.SelectedIndex = -1;
            cmbEmpleados.SelectedIndex = -1;
            cmbTipoTransaccion.SelectedIndex = -1;
            txtMonto.Clear();
            txtDescripcion.Clear();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialTransacciones();
        }

        // Cargar el historial de transacciones en el DataGridView
        private void CargarHistorialTransacciones()
        {
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente para ver su historial de transacciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
            var historial = transaccionDB.ObtenerTransaccionesPorCliente(idCliente);
            dataGridViewTransacciones.DataSource = historial;
        }
    }
}

