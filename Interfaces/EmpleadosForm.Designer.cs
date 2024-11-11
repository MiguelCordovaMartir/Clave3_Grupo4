
namespace Clave3_Grupo4.Interfaces
{
    partial class EmpleadosForm
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDUI = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.dataGridViewEmpleados = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.btnObternerClientes = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(297, 53);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificarEmpleado
            // 
            this.btnModificarEmpleado.Location = new System.Drawing.Point(297, 99);
            this.btnModificarEmpleado.Name = "btnModificarEmpleado";
            this.btnModificarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnModificarEmpleado.TabIndex = 1;
            this.btnModificarEmpleado.Text = "Modificar";
            this.btnModificarEmpleado.UseVisualStyleBackColor = true;
            this.btnModificarEmpleado.Click += new System.EventHandler(this.btnModificarEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(297, 141);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEmpleado.TabIndex = 2;
            this.btnEliminarEmpleado.Text = "Eliminar";
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(126, 102);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // txtDUI
            // 
            this.txtDUI.Location = new System.Drawing.Point(126, 144);
            this.txtDUI.Name = "txtDUI";
            this.txtDUI.Size = new System.Drawing.Size(100, 20);
            this.txtDUI.TabIndex = 5;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(126, 186);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(121, 21);
            this.cmbRol.TabIndex = 6;
            // 
            // dataGridViewEmpleados
            // 
            this.dataGridViewEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmpleados.Location = new System.Drawing.Point(50, 238);
            this.dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            this.dataGridViewEmpleados.Size = new System.Drawing.Size(502, 150);
            this.dataGridViewEmpleados.TabIndex = 7;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(452, 41);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 8;
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(563, 39);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(99, 23);
            this.btnBuscarEmpleado.TabIndex = 9;
            this.btnBuscarEmpleado.Text = "Buscar empleado";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // btnObternerClientes
            // 
            this.btnObternerClientes.Location = new System.Drawing.Point(306, 186);
            this.btnObternerClientes.Name = "btnObternerClientes";
            this.btnObternerClientes.Size = new System.Drawing.Size(164, 23);
            this.btnObternerClientes.TabIndex = 10;
            this.btnObternerClientes.Text = "Cargar todos los clientes";
            this.btnObternerClientes.UseVisualStyleBackColor = true;
            this.btnObternerClientes.Click += new System.EventHandler(this.btnObternerClientes_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(529, 89);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(109, 23);
            this.btnExportarExcel.TabIndex = 11;
            this.btnExportarExcel.Text = "Exportar a exel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // EmpleadosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 437);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnObternerClientes);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dataGridViewEmpleados);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtDUI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnEliminarEmpleado);
            this.Controls.Add(this.btnModificarEmpleado);
            this.Controls.Add(this.btnAgregar);
            this.Name = "EmpleadosForm";
            this.Text = "EmpleadosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDUI;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.DataGridView dataGridViewEmpleados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.Button btnObternerClientes;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}