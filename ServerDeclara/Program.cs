using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServerDeclara.Components;
using ServerDeclara.Datos;
using ServerDeclara.Servicios;
using ServerDeclara.Servicios_de_datos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string conexionBaseDatosLocal = "ConnectionStrings:LocalBD";
string conexionBaseDatosAzure = "ConnectionStrings:AzureBD";

builder.Services.AddDbContext<DeclaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetValue<string>(conexionBaseDatosLocal)));


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<UsuarioRepositorio>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
