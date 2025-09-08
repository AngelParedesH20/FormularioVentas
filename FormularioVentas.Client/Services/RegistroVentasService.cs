using FormularioVentas.Entities;
using System.Diagnostics;

namespace FormularioVentas.Client.Services
{
    public class RegistroVentasService
    {
        public List<ListaRepresentante> lista;
        public List<ListaRepresentante> listaGerentes;
        public SucursalesService sucursalesService { get; set; }

        public RegistroVentasService(SucursalesService _sucursalesService)
        {
            sucursalesService = _sucursalesService;

            listaGerentes = new List<ListaRepresentante>();
            listaGerentes.Add(new ListaRepresentante
            {
                Num_Empl = 100,
                Nombre = "Carlos Sanchez",
                Cargo = "Gerente",
                Fecha_Contrato = DateTime.Now.AddYears(-5),
                Ventas = 1500
            });
            listaGerentes.Add(new ListaRepresentante
            {
                Num_Empl = 101,
                Nombre = "Ana Gomez",
                Cargo = "Gerente",
                Fecha_Contrato = DateTime.Now.AddYears(-3),
                Ventas = 1200
            });
            lista = new List<ListaRepresentante>();
            lista.Add(new ListaRepresentante
            {
                Num_Empl = 001,
                Nombre = "Juan Perez",
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Now.AddYears(-2),
                Ventas = 700, 
                nombreSucursal = "La Paz",
                nombreGerente = "Ana Gomez"
            });
            lista.Add(new ListaRepresentante
            {
                Num_Empl = 002,
                Nombre = "Maria Lopez",
                Cargo = "Vendedor",
                Fecha_Contrato = DateTime.Now.AddYears(-1),
                Ventas = 450,
                nombreSucursal = "Trinidad",
                nombreGerente = "Carlos Sanchez"
            });
        } 
        public List<ListaRepresentante> ListarGerentes()
        {
            return listaGerentes;
        }
        public List<ListaRepresentante> ListarEmpleados()
        {
            return lista;
        }
        public void EliminarEmpleado(int numEmpl)
        {
            var listaQueda = lista.Where(p => p.Num_Empl != numEmpl ).ToList();
            lista = listaQueda;
        }
        public RepresentanteVentas RecuperarId(int numEmpl)
        {
            var obj = lista.Where(p => p.Num_Empl == numEmpl).FirstOrDefault();

            if (obj != null)
            {
                return new RepresentanteVentas { Num_Empl = obj.Num_Empl, Nombre = obj.Nombre, Edad = 18, Cargo = obj.Cargo, Fecha_Contrato = obj.Fecha_Contrato, nombreGerente = obj.nombreGerente ?? "", idSucursal = sucursalesService.RecuperarIdSucursal(obj.nombreSucursal), Ventas = obj.Ventas}; 
            }
            else return new RepresentanteVentas();

        }
        public string RecuperarNombreGerente(string nombreGerente)
        {
            var obj = listaGerentes.Where(p => p.nombreGerente == nombreGerente).FirstOrDefault();
            if (obj == null) return "Sin Gerente";
            else return obj.nombreGerente ?? string.Empty;
        }
        public void GuardarRegistro(RepresentanteVentas oRepresentante)
        {
            int numEmpl = lista.Select(p => p.Num_Empl).Max() + 1;
            lista.Add(new ListaRepresentante { Num_Empl = numEmpl, Nombre = oRepresentante.Nombre, Cargo = oRepresentante.Cargo, Fecha_Contrato = oRepresentante.Fecha_Contrato,nombreGerente = oRepresentante.nombreGerente, nombreSucursal = sucursalesService.RecuperarNombreSucursal(oRepresentante.idSucursal),Ventas = oRepresentante.Ventas });
        }
    }
}
