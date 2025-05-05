using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RaidPlanner.Front;
using RaidPlanner.Front.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<UserStateService>();
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<AvailabilityService>();
builder.Services.AddScoped<RaidService>();
builder.Services.AddScoped<RaidSessionService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7131/") });

await builder.Build().RunAsync();
