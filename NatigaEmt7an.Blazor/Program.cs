using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NatigaEmt7an.Blazor.Services;
using NewsBlazorAppAdmin.Services;

namespace NatigaEmt7an.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient("Client", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7258/api/");
        });
        builder.Services.AddScoped<ApiServices>();

        builder.Services.AddScoped<GovernorateServices>();
        builder.Services.AddScoped<SchoolServices>();
        builder.Services.AddScoped<StudentServices>();
        builder.Services.AddScoped<AdministrationServices>();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services
            .AddBlazorise(options => { options.Immediate = true;  options.ProductToken = "COMMUNITY"; })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

        await builder.Build().RunAsync();
    }
}
