using FormularioVentas.Client.Services.Empleado;
using FormularioVentas.Entities.Cliente;
using FormularioVentas.Entities.Representante;

namespace FormularioVentas.Client.Services.Cliente
{
    public class ClienteService
    {
        public List<ListaCliente> listaCliente;
        public List<RepresentanteVentas> representanteClientes;
        public RegistroVentasService registroVentasService { get; set; }
        public ClienteService(RegistroVentasService _registroVentasService)
        {
            registroVentasService = _registroVentasService;
            listaCliente = new List<ListaCliente>();
            listaCliente.Add(new ListaCliente
            {
                codigoCliente = 1,
                nombreCliente = "Industrias S.A.",
                nombreRepresentanteAsignado = "Juan Perez",
                limiteCredito = 5000
            });
            listaCliente.Add(new ListaCliente
            {
                codigoCliente = 2,
                nombreCliente = "Comercializadora Ltda.",
                nombreRepresentanteAsignado = "Maria Lopez",
                limiteCredito = 3000
            });
        }
        public List<ListaCliente> ListarClientes()
        {
            return listaCliente;
        }
        public void EliminarCliente(int codigoCliente)
        {
            var listaQueda = listaCliente.Where(x=>x.codigoCliente != codigoCliente).ToList();
            listaCliente = listaQueda;
        }
        public ClienteVentas RecuperarIdCliente(int codigoCliente)
        {
            var obj = listaCliente.Where(p => p.codigoCliente == codigoCliente).FirstOrDefault();
            if (obj != null)
            {
                return new ClienteVentas
                {
                    codigoCliente = obj.codigoCliente, nombreCliente = obj.nombreCliente, representanteAsignado = registroVentasService.RecuperarIdRepresentante(obj.nombreRepresentanteAsignado), limiteCredito = obj.limiteCredito
                };
            }
            else return new ClienteVentas();
        }
        public void GuardarCliente(ClienteVentas oClienteVentas)
        {
            int idCliente = listaCliente.Select(p => p.codigoCliente).Max() + 1;
            listaCliente.Add(new ListaCliente
            {
                codigoCliente = idCliente, nombreCliente = oClienteVentas.nombreCliente, nombreRepresentanteAsignado = registroVentasService.RecuperarNombreRepresentante(oClienteVentas.representanteAsignado), limiteCredito = oClienteVentas.limiteCredito
            });
        }
        public List<ListaCliente> FiltrarClientes(string _nombreCliente)
        {
            List<ListaCliente> l = ListarClientes();
            if (string.IsNullOrEmpty(_nombreCliente))
            {
                return l;
            }
            else
            {
                List<ListaCliente> listaTemp = l.Where(p => p.nombreCliente.ToUpper().Contains(_nombreCliente.ToUpper())).ToList();
                return listaTemp;
            }
        }
    }
}
