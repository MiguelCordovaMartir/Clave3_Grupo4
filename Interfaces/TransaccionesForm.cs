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
        private readonly TransaccionDB transaccionDB = new TransaccionDB();
        private readonly ClienteDB clienteDB = new ClienteDB();
        private readonly EmpleadoDB empleadoDB = new EmpleadoDB();
        public TransaccionesForm()
        {
            InitializeComponent();
            ConfigurarComboBoxes(); // Configura los ComboBoxes para que no permitan entrada de texto libre
            CargarClientes(); // Carga la lista de clientes en el ComboBox correspondiente
            CargarEmpleados(); // Carga la lista de empleados en el ComboBox correspondiente
            CargarTipoTransaccion(); // Carga los tipos de transacción en el ComboBox
            LimpiarCamposTransaccion(); // Limpia los campos del formulario
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
            try
            {
                DataTable clientes = clienteDB.ObtenerTodosClientes();
                cmbClientes.DataSource = clientes; // Asigna los datos de clientes al ComboBox
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "IdCliente";
                cmbClientes.SelectedIndex = -1; // Deselecciona cualquier opción
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = empleadoDB.ObtenerTodosEmpleados();
                cmbEmpleados.DataSource = empleados; // Asigna los datos de empleados al ComboBox
                cmbEmpleados.DisplayMember = "Nombre";
                cmbEmpleados.ValueMember = "IdEmpleado";
                cmbEmpleados.SelectedIndex = -1; // Deselecciona cualquier opción
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Configura el ComboBox de tipo de transacción
        private void CargarTipoTransaccion()
        {
            cmbTipoTransaccion.Items.AddRange(new[] { "Abono", "Cargo" }); // Agrega tipos de transacción al ComboBox
            cmbTipoTransaccion.SelectedIndex = -1; // Deselecciona cualquier opción
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

            if (!ValidarCamposTransaccion()) return; // Valida que los campos no estén vacíos

            // Crea una nueva transacción con los datos ingresados
            Transaccion transaccion = new Transaccion
            {
                IdCliente = Convert.ToInt32(cmbClientes.SelectedValue),
                IdEmpleado = cmbEmpleados.SelectedValue != null ? (int?)Convert.ToInt32(cmbEmpleados.SelectedValue) : null,
                TipoTransaccion = cmbTipoTransaccion.SelectedItem.ToString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                Descripcion = txtDescripcion.Text
            };

            // Intenta insertar la transacción en la base de datos
            if (transaccionDB.InsertarTransaccion(transaccion))
            {
                MessageBox.Show("Transacción agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialTransacciones(); // Recarga el historial de transacciones
                LimpiarCamposTransaccion(); // Limpia los campos del formulario
            }
            else
            {
                MessageBox.Show("Error al agregar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCamposTransaccion()
        {
            // Verifica que todos los campos requeridos estén llenos
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTipoTransaccion.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de transacción.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido (mayor que cero).", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción para la transacción.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Limpiar campos del formulario
        private void LimpiarCamposTransaccion()
        {

            // Limpia todos los campos del formulario
            cmbClientes.SelectedIndex = -1;
            cmbEmpleados.SelectedIndex = -1;
            cmbTipoTransaccion.SelectedIndex = -1;
            txtMonto.Clear();
            txtDescripcion.Clear();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialTransacciones(); // Carga el historial de transacciones del cliente seleccionado
        }

        // Cargar el historial de transacciones en el DataGridView
        private void CargarHistorialTransacciones()
        {
            try
            {
                if (cmbClientes.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un cliente para ver su historial de transacciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
                dataGridViewTransacciones.DataSource = transaccionDB.ObtenerTransaccionesPorCliente(idCliente); // Carga las transacciones en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

