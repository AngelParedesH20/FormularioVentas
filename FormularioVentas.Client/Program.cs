using FormularioVentas.Client;
using FormularioVentas.Client.Pages;
using FormularioVentas.Client.Services.Cliente;
using FormularioVentas.Client.Services.Empleado;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<RegistroVentasService>();
builder.Services.AddScoped<SucursalesService>();
builder.Services.AddScoped<ClienteService>();

await builder.Build().RunAsync();
