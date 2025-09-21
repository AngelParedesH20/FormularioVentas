using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities.Cliente
{
    public class ListaCliente
    {
        public int codigoCliente { get; set; }
        public string nombreCliente { get; set; } = string.Empty;
        public string nombreRepresentanteAsignado { get; set; } = string.Empty;
        public decimal limiteCredito { get; set; }
    }
}
