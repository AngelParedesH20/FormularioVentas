using FormularioVentas.Entities.Representante;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities.Cliente
{
    public class ClienteVentas
    {
        [Required(ErrorMessage = "El número de cliente es obligatorio.")]
        public int codigoCliente { get; set; }

        [Required(ErrorMessage = "El nombre de cliente es obligatorio.")]
        public string nombreCliente { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un representante")]
        public int representanteAsignado { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "El limite de credito debe ser un valor numérico.")]
        public decimal limiteCredito { get; set; }


    }
}
