using FormularioVentas.Entities.Representante;

namespace FormularioVentas.Client.Services.Empleado
{
    public class SucursalesService
    {
        public List<SucursalVenta> lista;
        public SucursalesService()
        {
            lista = new List<SucursalVenta>();
            lista.Add(new SucursalVenta
            {
                idSucursal = 1,
                nombreSucursal = "La Paz"
            });
            lista.Add(new SucursalVenta
            {
                idSucursal = 2,
                nombreSucursal = "Sucre"
            });
            lista.Add(new SucursalVenta
            {
                idSucursal = 3,
                nombreSucursal = "Santa Cruz"
            });
            lista.Add(new SucursalVenta
            {
                idSucursal = 4,
                nombreSucursal = "Cochabamba"
            });
            lista.Add(new SucursalVenta
            {
                idSucursal = 5,
                nombreSucursal = "Trinidad"
            });
        }
        public List<SucursalVenta> ListarSucursales()
        {
            return lista;
        }
        public int RecuperarIdSucursal(string nombreSucursal)
        {
            var obj = lista.Where(p => p.nombreSucursal == nombreSucursal).FirstOrDefault();
            if (obj == null) return 0;
            else return obj.idSucursal;
        } 
        public string RecuperarNombreSucursal(int idSucursal)
        {
            var obj = lista.Where(p => p.idSucursal == idSucursal).FirstOrDefault();
            if (obj == null) return string.Empty;
            else return obj.nombreSucursal ?? string.Empty;
        }
    }
}
