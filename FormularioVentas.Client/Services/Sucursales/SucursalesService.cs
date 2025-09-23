using FormularioVentas.Client.Services.Cliente;
using FormularioVentas.Client.Services.Empleado;
using FormularioVentas.Entities.Representante;
using FormularioVentas.Entities.Sucursal;

namespace FormularioVentas.Client.Services.Sucursales
{
    public class SucursalesService
    {
        public List<ListaSucursalVenta> lista;
        public List<Ciudades> listaCiudades;

        public CiudadService ciudadService { get; set; } 
        public GerenteService gerenteService { get; set; }

        public SucursalesService(CiudadService _ciudadService, GerenteService _gerenteService)
        {
            ciudadService = _ciudadService;
            gerenteService = _gerenteService;
            lista = new List<ListaSucursalVenta>();
            lista.Add(new ListaSucursalVenta
            {
                codigoSucursal = 1,
                nombreCiudad = "La Paz",
                region = "Sur",
                nombreDirector = "Carlos Sanchez",
                objetivoVenta = 1000,
                ventasReales = 800
            });
            lista.Add(new ListaSucursalVenta
            {
                codigoSucursal = 2,
                nombreCiudad = "Santa Cruz",
                region = "Norte",
                nombreDirector = "Carlos Sanchez",
                objetivoVenta = 5000,
                ventasReales = 1200
            });
            this.gerenteService = gerenteService;
        }
        public List<ListaSucursalVenta> ListarSucursales()
        {
            return lista;
        }
        public void EliminarSucursal(int codigoSucursal)
        {
            var listaQueda = lista.Where(p => p.codigoSucursal != codigoSucursal).ToList();
            lista = listaQueda;
        }
        public SucursalVenta RecuperarId(int codigoSucursal)
        {
            var obj = lista.Where(p => p.codigoSucursal == codigoSucursal).FirstOrDefault();

            if (obj != null)
            {
                return new SucursalVenta { codigoSucursal = obj.codigoSucursal, idCiudad = ciudadService.RecuperarIdCiudad(obj.nombreCiudad), region= obj.region, idDirector = gerenteService.RecuperarIdGerente(obj.nombreDirector), ventasReales = obj.ventasReales, objetivoVenta = obj.objetivoVenta};
            }
            else return new SucursalVenta();
        }
        public void GuardarRegistro(SucursalVenta oSucursal)
        {
            int codigo = lista.Select(p => p.codigoSucursal).Max() + 1;
            lista.Add(new ListaSucursalVenta { codigoSucursal = codigo, nombreCiudad = ciudadService.RecuperarNombreCiudad(oSucursal.idCiudad), region = oSucursal.region, nombreDirector = gerenteService.RecuperarNombreGerente(oSucursal.idDirector), ventasReales = oSucursal.ventasReales, objetivoVenta = oSucursal.objetivoVenta });
        }
        public List<ListaSucursalVenta> FiltrarSucursales(string nombreSucursal)
        {
            List<ListaSucursalVenta> l = ListarSucursales();
            if (string.IsNullOrEmpty(nombreSucursal))
            {
                return l;
            }
            else
            {
                List<ListaSucursalVenta> listaTemp = l.Where(p => p.nombreCiudad.ToUpper().Contains(nombreSucursal.ToUpper())).ToList();
                return listaTemp;
            }
        }
        public int RecuperarIdSucursal(string nombreSucursal)
        {
            var obj = lista.Where(p => p.nombreCiudad == nombreSucursal).FirstOrDefault();
            if (obj == null) return 0;
            else return obj.codigoSucursal;
        } 
        public string RecuperarNombreSucursal(int idSucursal)
        {
            var obj = lista.Where(p => p.codigoSucursal == idSucursal).FirstOrDefault();
            if (obj == null) return string.Empty;
            else return obj.nombreCiudad ?? string.Empty;
        }
    }
}
