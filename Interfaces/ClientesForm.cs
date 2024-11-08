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
    public partial class ClientesForm : Form
    {
        private ClienteDB clienteDB;
        public ClientesForm()
        {
            InitializeComponent();
            clienteDB = new ClienteDB();
            CargarTipoProductoComboBox();
            CargarClientesEnGrid();

            dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
        }
        private void CargarTipoProductoComboBox()
        {
            cmbTipoProducto.Items.AddRange(new string[]
            {
                "CuentaAhorro",
                "CuentaCorriente",
                "TarjetaDebito",
                "TarjetaCredito",
                "PrestamoPersonal",
                "PrestamoAgropecuario",
                "PrestamoHipotecario"
            });
        }
        // Método para cargar los datos de clientes en el DataGridView
        private void CargarClientesEnGrid()
        {
            DataTable dataTable = clienteDB.ObtenerTodosClientes();
            dataGridViewClientes.DataSource = dataTable;
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos de entrada
            txtNombre.Clear();
            txtApellido.Clear();
            txtDUI.Clear();
            cmbTipoProducto.SelectedIndex = -1;
            txtBilleteraVirtual.Clear();
        }
        // Validación de campos vacíos
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDUI.Text) ||
                cmbTipoProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                TipoProducto = cmbTipoProducto.SelectedItem.ToString(),
                BilleteraVirtual = decimal.TryParse(txtBilleteraVirtual.Text, out decimal billetera) ? billetera : 0
            };

            if (clienteDB.InsertarCliente(cliente))
            {
                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientesEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IdCliente"].Value);
            Cliente cliente = new Cliente
            {
                IdCliente = idCliente,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                TipoProducto = cmbTipoProducto.SelectedItem.ToString(),
                BilleteraVirtual = decimal.TryParse(txtBilleteraVirtual.Text, out decimal billetera) ? billetera : 0
            };

            if (clienteDB.ModificarCliente(cliente))
            {
                MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientesEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IdCliente"].Value);

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                if (clienteDB.EliminarCliente(idCliente))
                {
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientesEnGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que se selecciona una fila válida
            {
                DataGridViewRow filaSeleccionada = dataGridViewClientes.Rows[e.RowIndex];

                // Cargar los datos del cliente seleccionado en los controles de entrada
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtDUI.Text = filaSeleccionada.Cells["DUI"].Value.ToString();
                cmbTipoProducto.SelectedItem = filaSeleccionada.Cells["TipoProducto"].Value.ToString();
                txtBilleteraVirtual.Text = filaSeleccionada.Cells["BilleteraVirtual"].Value.ToString();
            }
        }
    }
}
