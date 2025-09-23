using FormularioVentas.Entities.Representante;
using FormularioVentas.Entities.Sucursal;

namespace FormularioVentas.Client.Services.Empleado
{
    public class GerenteService
    {
        public List<GerenteVentas> listaGerentes;
        public GerenteService()
        {
            listaGerentes = new List<GerenteVentas>();
            listaGerentes.Add(new GerenteVentas
            {
                idGerente = 1,
                nombreGerente = "Carlos Sanchez"
            });
            listaGerentes.Add(new GerenteVentas
            {
                idGerente = 2,
                nombreGerente = "Ana Gomez"
            });
        }
        public List<GerenteVentas> ListarGerentes()
        {
            return listaGerentes;
        }
        public int RecuperarIdGerente(string nombreGerente)
        {
            var obj = listaGerentes.Where(p => p.nombreGerente == nombreGerente).FirstOrDefault();
            if (obj == null) return 0;
            else return obj.idGerente;
        }
        public string RecuperarNombreGerente(int _idGerente)
        {
            var obj = listaGerentes.Where(p => p.idGerente == _idGerente).FirstOrDefault();
            if (obj == null) return string.Empty;
            else return obj.nombreGerente ?? string.Empty;
        }
    }
}
