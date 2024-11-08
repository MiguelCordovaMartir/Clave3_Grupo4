﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave3_Grupo4.DataBase; 
using Clave3_Grupo4.Clases;

namespace Clave3_Grupo4.Interfaces
{
    public partial class MainForm : Form
    {
        private Empleado empleadoActual; // Variable para almacenar el empleado actual

        // Constructor sin parámetros
        public MainForm()
        {
            InitializeComponent();
        }

        // Constructor que recibe un objeto Empleado
        public MainForm(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado; // Asignamos el empleado recibido a la variable
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de clientes
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.ShowDialog();
        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de Empleados
            EmpleadosForm EmpleadosForm = new EmpleadosForm();
            EmpleadosForm.ShowDialog();
        }
    }
}
