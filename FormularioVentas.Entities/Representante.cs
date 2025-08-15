using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FormularioVentas.Entities
{
    public class Representante
    {
        [Required(ErrorMessage = "EL NÚMERO DE EMPLEADO ES REQUERIDO")]
        public int Num_Empl { get; set; }

        [Required(ErrorMessage = "EL NOMBRE ES REQUERIDO")]
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }

        [Required(ErrorMessage = "EL CARGO ES REQUERIDO")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "LA FECHA DE CONTRATO ES REQUERIDA")]
        public DateTime Fecha_Contrato { get; set; }

        [Required(ErrorMessage = "LA CUOTA ES REQUERIDA")]
        public double Cuota { get; set; }

        [Required(ErrorMessage = "EL NÚMERO DE VENTAS ES REQUERIDO")]
        public int Venta { get; set; }

    }
}
