using FormularioVentas.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FormularioVentas.Test
{
    public class RepresentanteVentasTest
    {
        // Método auxiliar para validar un objeto con DataAnnotations
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

        [Fact]
        public void ValidacionDebeFallarCuandoCamposEstanVacios()
        {
            var representante = new RepresentanteVentas();
            var errores = ValidarModelo(representante);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El número de empleado es obligatorio."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El nombre es obligatorio."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El cargo es obligatorio."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La fecha de contrato es obligatoria."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La cuota es obligatoria."));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Las ventas son obligatorias."));
        }

        [Fact]
        public void ValidacionDebePasarConDatosCorrectos()
        {
            var representante = new RepresentanteVentas()
            {
                Num_Empl = 101,
                Nombre = "Juan Perez",
                Edad = 25,
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Today,
                Cuota = 1000.50m,
                Ventas = 500m
            };
            var errores = ValidarModelo(representante);

            Assert.Empty(errores);
        }

        [Fact]
        public void ValidacionDebeFallarCuandoEdadEsMenorDe18()
        {
            var representante = new RepresentanteVentas()
            {
                Num_Empl = 102,
                Nombre = "Maria Lopez",
                Edad = 17,
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Today,
                Cuota = 1000.50m,
                Ventas = 500m
            };
            var errores = ValidarModelo(representante);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La edad debe ser mayor o igual a 18."));
        }
    }
}
