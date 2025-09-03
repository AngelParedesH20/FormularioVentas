using FormularioVentas.Entities;

namespace FormularioVentas.Client.Services
{
    public class RegistroVentasService
    {
        public List<ListaRepresentante> lista;
        public RegistroVentasService()
        {
            lista = new List<ListaRepresentante>();
            lista.Add(new ListaRepresentante
            {
                Num_Empl = "001",
                Nombre = "Juan Perez",
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Now.AddYears(-2),
                Ventas = 700
            });
            lista.Add(new ListaRepresentante
            {
                Num_Empl = "002",
                Nombre = "Maria Lopez",
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Now.AddYears(-1),
                Ventas = 450
            });
        } 
        public List<ListaRepresentante> ListarEmpleados()
        {
            return lista;
        }
        public void EliminarEmpleado(string numEmpl)
        {
            var listaQueda = lista.Where(p => p.Num_Empl != numEmpl ).ToList();
            lista = listaQueda;
        }
        public RepresentanteVentas RecuperarId(string numEmpl)
        {
            var obj = lista.Where(p => p.Num_Empl.Equals(numEmpl)).FirstOrDefault();
            if (obj != null)
            {
                return new RepresentanteVentas { Num_Empl = obj.Num_Empl, Nombre = obj.Nombre, Edad = 18, Cargo = obj.Cargo, Fecha_Contrato = obj.Fecha_Contrato, Ventas = obj.Ventas}; 
            }
            else return new RepresentanteVentas();
        }
        public void GuardarRegistro(RepresentanteVentas oRepresentante)
        {
            lista.Add(new ListaRepresentante { Num_Empl = oRepresentante.Num_Empl, Nombre = oRepresentante.Nombre, Cargo = oRepresentante.Cargo, Fecha_Contrato = oRepresentante.Fecha_Contrato, Ventas = oRepresentante.Ventas });
        }
    }
}
