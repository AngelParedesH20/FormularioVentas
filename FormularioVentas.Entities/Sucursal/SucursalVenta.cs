using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioVentas.Entities.Sucursal
{
    public class SucursalVenta
    {
        [Required(ErrorMessage = "El código de la Sucursal es obligatorio.")]
        public int codigoSucursal { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Ciudad")]
        public int idCiudad { get; set; }

        [Required(ErrorMessage = "La región es obligatoria.")]
        public string region { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Director")]
        public int  idDirector { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Objetivo de Ventas")]
        public int objetivoVenta { get; set; }

        [Range(0, int.MaxValue)]
        public int ventasReales { get; set; }
    }
}
