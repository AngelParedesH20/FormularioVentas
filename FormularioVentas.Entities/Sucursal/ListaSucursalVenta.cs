using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities.Sucursal
{
    public class ListaSucursalVenta
    {
        public int codigoSucursal { get; set; }
        public string nombreCiudad { get; set; } = string.Empty;
        public string region { get; set; } = string.Empty;
        public string nombreDirector { get; set; } = string.Empty;
        public int objetivoVenta { get; set; }
        public int ventasReales { get; set; }
    }
}

