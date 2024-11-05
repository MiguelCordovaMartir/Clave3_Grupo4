using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4.Clases
{
    public class Transaccion
    {
        //maneja las transacciones de los clientes.
        public int IdTransaccion { get; set; }
        public int IdCliente { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
