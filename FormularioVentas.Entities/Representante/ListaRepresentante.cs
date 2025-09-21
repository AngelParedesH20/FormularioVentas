using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities.Representante
{
    public class ListaRepresentante
    {
        public int Num_Empl { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
        public DateTime? Fecha_Contrato { get; set; }
        public decimal? Ventas { get; set; }
        public string? nombreSucursal { get; set; }
        public string? nombreGerente { get; set; }

    }
}
