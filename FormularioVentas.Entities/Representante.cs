using System.ComponentModel.DataAnnotations;

namespace FormularioVentas.Entities
{
    public class RepresentanteVentas
    {
        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        public string? Num_Empl { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        [Range(18, 150, ErrorMessage = "La edad debe ser mayor o igual a 18.")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public string? Cargo { get; set; }

        [Required(ErrorMessage = "La fecha de contrato es obligatoria.")]
        public DateTime? Fecha_Contrato { get; set; }

        [Required(ErrorMessage = "La cuota es obligatoria.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cuota debe ser un valor numérico positivo.")]
        public decimal? Cuota { get; set; }

        [Required(ErrorMessage = "Las ventas son obligatorias.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Las ventas deben ser un valor numérico.")]
        public decimal? Ventas { get; set; }
    }
}
