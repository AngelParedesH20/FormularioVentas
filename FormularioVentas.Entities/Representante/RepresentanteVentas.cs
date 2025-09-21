using System.ComponentModel.DataAnnotations;

namespace FormularioVentas.Entities.Representante
{
    public class RepresentanteVentas
    {
        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        public int Num_Empl { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        [Range(18, 100, ErrorMessage = "La edad debe ser mayor o igual a 18.")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public string? Cargo { get; set; }

        [Required(ErrorMessage = "La fecha de contrato es obligatoria.")]
        [Range(typeof(DateTime),"01-01-1990","01-01-2100", ErrorMessage = "La fecha debe estar en el rango (01-01-1990)-(01-01-2100)")]
        public DateTime? Fecha_Contrato { get; set; }

        [Required(ErrorMessage = "La cuota es obligatoria.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cuota debe ser un valor numérico positivo.")]
        public decimal? Cuota { get; set; }

        [Required(ErrorMessage = "Las ventas son obligatorias.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Las ventas deben ser un valor numérico.")]
        public decimal? Ventas { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Debe seleccionar una Sucursal")]
        public int idSucursal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Gerente")]
        public string nombreGerente { get; set; } = string.Empty;

    }
}
