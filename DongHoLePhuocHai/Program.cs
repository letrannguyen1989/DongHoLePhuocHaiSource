using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DongHoLePhuocHai;
using DongHoLePhuocHai.Services;
using DongHoLePhuocHai.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load configuration from appsettings.json
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();

// Register services
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IFamilyService, FamilyService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiSettings?.BaseUrl ?? builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
