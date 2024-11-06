using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave3_Grupo4.DataBase; // Asegúrate de que está correctamente dirigido a la carpeta DataBase.
using Clave3_Grupo4.Clases;



namespace Clave3_Grupo4.Interfaces
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener los datos del usuario ingresado
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                // Validación básica de entrada
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Instancia de UsuarioDB para verificar el usuario
                UsuarioDB usuarioDB = new UsuarioDB();
                Empleado empleado = usuarioDB.ObtenerUsuarioPorDUI(usuario); // Suponiendo que el DUI es el usuario

                // Verificar si el usuario existe y la contraseña coincide
                if (empleado != null && contraseña == empleado.DUI) // Solo como ejemplo, usa una verificación más segura en producción
                {
                    // Ocultar el formulario de login y mostrar el formulario principal
                    this.Hide();
                    MainForm mainForm = new MainForm(empleado); // Pasar el objeto empleado al formulario principal
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje en caso de error
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
