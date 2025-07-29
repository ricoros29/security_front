using BlazorApp.Components;
using BlazorApp.DTO;
using BlazorApp.Interfaces;
using BlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

//Habilitar logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("WebAPI:uri").Value ?? string.Empty) });
builder.Services.AddScoped<IService, HttpService>();
builder.Services.AddSingleton<IGlobalState, GlobalState>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Expiration = TimeSpan.FromHours(1);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
