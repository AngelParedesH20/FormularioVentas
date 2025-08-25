using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities
{
    public class ListaRepresentante
    {
        public string? Num_Empl { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
        public DateTime? Fecha_Contrato { get; set; }
        public decimal? Ventas { get; set; }

    }
}
