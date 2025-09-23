using FormularioVentas.Client.Services.Sucursales;
using FormularioVentas.Entities.Representante;
using System.Diagnostics;

namespace FormularioVentas.Client.Services.Empleado
{
    public class RegistroVentasService
    {
        public List<ListaRepresentante> lista;
        public SucursalesService sucursalesService { get; set; }
        public GerenteService gerenteService { get; set; }

        public RegistroVentasService(SucursalesService _sucursalesService, GerenteService _gerenteService)
        {
            sucursalesService = _sucursalesService;
            gerenteService = _gerenteService;

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
                return new RepresentanteVentas { Num_Empl = obj.Num_Empl, Nombre = obj.Nombre, Edad = 18, Cargo = obj.Cargo, Fecha_Contrato = obj.Fecha_Contrato, idGerente = gerenteService.RecuperarIdGerente(obj.nombreGerente), idSucursal = sucursalesService.RecuperarIdSucursal(obj.nombreSucursal), Ventas = obj.Ventas, Cuota = 1000}; 
            }
            else return new RepresentanteVentas();

        }
        
        public void GuardarRegistro(RepresentanteVentas oRepresentante)
        {
            int numEmpl = lista.Select(p => p.Num_Empl).Max() + 1;
            lista.Add(new ListaRepresentante { Num_Empl = numEmpl, Nombre = oRepresentante.Nombre, Cargo = oRepresentante.Cargo, Fecha_Contrato = oRepresentante.Fecha_Contrato,nombreGerente = gerenteService.RecuperarNombreGerente(oRepresentante.idGerente), nombreSucursal = sucursalesService.RecuperarNombreSucursal(oRepresentante.idSucursal),Ventas = oRepresentante.Ventas });
        }

        public List<ListaRepresentante> FiltrarRepresentantes(string nombreRep)
        {
            List<ListaRepresentante> l = ListarEmpleados();
            if (string.IsNullOrEmpty(nombreRep))
            {
                return l;
            }
            else
            {
                List<ListaRepresentante> listaTemp = l.Where(p => p.Nombre.ToUpper().Contains(nombreRep.ToUpper())).ToList();
                return listaTemp;
            }
        }
        public int RecuperarIdRepresentante(string nombreRep)
        {
            var obj = lista.Where(p => p.Nombre == nombreRep).FirstOrDefault();
            if (obj == null) return 0;
            else return obj.Num_Empl;
        }
        public string RecuperarNombreRepresentante(int idRep)
        {
            var obj = lista.Where(p => p.Num_Empl == idRep).FirstOrDefault();
            if (obj == null) return "Sin representante";
            else return obj.Nombre ?? string.Empty;
        }
    }
}
