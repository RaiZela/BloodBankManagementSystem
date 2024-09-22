using BloodBankManagementSystem.Client;
using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44383/api/") });

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddTransient<IClinicService, ClinicService>();
builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Services.AddTransient<IDonationSymptomsService, DonationSymptomsService>();
builder.Services.AddTransient<IDonationTherapiesService, DonationTherapiesService>();
builder.Services.AddTransient<IAntibodiesService, AntibodiesService>();
builder.Services.AddTransient<IQuestionsService, QuestionsService>();
builder.Services.AddTransient<IPoliciesService, PoliciesService>();

await builder.Build().RunAsync();
