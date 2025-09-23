using FormularioVentas.Entities.Sucursal;

namespace FormularioVentas.Client.Services.Sucursales
{
    public class CiudadService
    {
        public List<Ciudades> listaCiudades;
        public CiudadService()
        {
            listaCiudades = new List<Ciudades>();
            listaCiudades.Add(new Ciudades
            {
                codigoCiudad = 1,
                nombreCiudad = "La Paz"
            });
            listaCiudades.Add(new Ciudades
            {
                codigoCiudad = 2,
                nombreCiudad = "Sucre"
            });
            listaCiudades.Add(new Ciudades
            {
                codigoCiudad = 3,
                nombreCiudad = "Santa Cruz"
            });
            listaCiudades.Add(new Ciudades
            {
                codigoCiudad = 4,
                nombreCiudad = "Cochabamba"
            });
            listaCiudades.Add(new Ciudades
            {
                codigoCiudad = 5,
                nombreCiudad = "Trinidad"
            });
        }
        public List<Ciudades> ListarCiudades()
        {
            return listaCiudades;
        }
        public int RecuperarIdCiudad(string nombreCiudad)
        {
            var obj = listaCiudades.Where(p => p.nombreCiudad == nombreCiudad).FirstOrDefault();
            if (obj == null) return 0;
            else return obj.codigoCiudad;
        }
        public string RecuperarNombreCiudad(int _codigociudad)
        {
            var obj = listaCiudades.Where(p => p.codigoCiudad == _codigociudad).FirstOrDefault();
            if (obj == null) return string.Empty;
            else return obj.nombreCiudad ?? string.Empty;
        }
    }
}
