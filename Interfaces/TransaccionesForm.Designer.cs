
namespace Clave3_Grupo4.Interfaces
{
    partial class TransaccionesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.cmbEmpleados = new System.Windows.Forms.ComboBox();
            this.dtpFechaTransaccion = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregarTransaccion = new System.Windows.Forms.Button();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.dataGridViewTransacciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(164, 59);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(121, 21);
            this.cmbClientes.TabIndex = 0;
            // 
            // cmbEmpleados
            // 
            this.cmbEmpleados.FormattingEnabled = true;
            this.cmbEmpleados.Location = new System.Drawing.Point(164, 96);
            this.cmbEmpleados.Name = "cmbEmpleados";
            this.cmbEmpleados.Size = new System.Drawing.Size(121, 21);
            this.cmbEmpleados.TabIndex = 1;
            // 
            // dtpFechaTransaccion
            // 
            this.dtpFechaTransaccion.Location = new System.Drawing.Point(164, 124);
            this.dtpFechaTransaccion.Name = "dtpFechaTransaccion";
            this.dtpFechaTransaccion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaTransaccion.TabIndex = 2;
            // 
            // cmbTipoTransaccion
            // 
            this.cmbTipoTransaccion.FormattingEnabled = true;
            this.cmbTipoTransaccion.Location = new System.Drawing.Point(164, 165);
            this.cmbTipoTransaccion.Name = "cmbTipoTransaccion";
            this.cmbTipoTransaccion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoTransaccion.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(164, 202);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(164, 237);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // btnAgregarTransaccion
            // 
            this.btnAgregarTransaccion.Location = new System.Drawing.Point(465, 59);
            this.btnAgregarTransaccion.Name = "btnAgregarTransaccion";
            this.btnAgregarTransaccion.Size = new System.Drawing.Size(115, 23);
            this.btnAgregarTransaccion.TabIndex = 6;
            this.btnAgregarTransaccion.Text = "AgregarTransaccion";
            this.btnAgregarTransaccion.UseVisualStyleBackColor = true;
            this.btnAgregarTransaccion.Click += new System.EventHandler(this.btnAgregarTransaccion_Click);
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.Location = new System.Drawing.Point(465, 93);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(75, 23);
            this.btnVerHistorial.TabIndex = 7;
            this.btnVerHistorial.Text = "Ver Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = true;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // dataGridViewTransacciones
            // 
            this.dataGridViewTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransacciones.Location = new System.Drawing.Point(38, 285);
            this.dataGridViewTransacciones.Name = "dataGridViewTransacciones";
            this.dataGridViewTransacciones.Size = new System.Drawing.Size(637, 150);
            this.dataGridViewTransacciones.TabIndex = 8;
            // 
            // TransaccionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewTransacciones);
            this.Controls.Add(this.btnVerHistorial);
            this.Controls.Add(this.btnAgregarTransaccion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.cmbTipoTransaccion);
            this.Controls.Add(this.dtpFechaTransaccion);
            this.Controls.Add(this.cmbEmpleados);
            this.Controls.Add(this.cmbClientes);
            this.Name = "TransaccionesForm";
            this.Text = "TransaccionesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.ComboBox cmbEmpleados;
        private System.Windows.Forms.DateTimePicker dtpFechaTransaccion;
        private System.Windows.Forms.ComboBox cmbTipoTransaccion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAgregarTransaccion;
        private System.Windows.Forms.Button btnVerHistorial;
        private System.Windows.Forms.DataGridView dataGridViewTransacciones;
    }
}