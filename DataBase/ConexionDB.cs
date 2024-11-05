using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Clave3_Grupo4.DataBase
{
    public class ConexionDB
    {

        private MySqlConnection conexion;

        public ConexionDB()
        {
            //Permite la conexion con la base de datos 
            string connectionString = "Server=localhost; Database=acoemprendedores; Uid=root; Pwd=root;";
            conexion = new MySqlConnection(connectionString);
        }

        public MySqlConnection ObtenerConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                //abre la conexion 
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                //cierra la conexion
                conexion.Close();
            }
        }
    }
}
