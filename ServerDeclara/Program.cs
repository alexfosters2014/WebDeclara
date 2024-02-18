using Blazored.Modal;
using Blazored.Toast;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Radzen;
using ServerDeclara.Components;
using ServerDeclara.Datos;
using ServerDeclara.Servicios;
using ServerDeclara.Servicios_de_datos;
using ServerDeclara.Validadores;
using static OpenAI.ObjectModels.SharedModels.IOpenAiModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string conexionBaseDatosLocal = "ConnectionStrings:LocalBD";
string conexionBaseDatosAzure = "ConnectionStrings:AzureBD";

builder.Services.AddDbContext<DeclaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetValue<string>(conexionBaseDatosLocal)), ServiceLifetime.Transient);

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddRadzenComponents();


builder.Services.AddScoped<BlobAzureServicio>();

builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<UsuarioRepositorio>();

builder.Services.AddScoped<ParametroServicio>();
builder.Services.AddScoped<ParametroRepositorio>();

builder.Services.AddScoped<IRPFServicio>();
builder.Services.AddScoped<IRPFRepositorio>();

builder.Services.AddScoped<IVAServicio>();
builder.Services.AddScoped<IVARepositorio>();

builder.Services.AddScoped<ComercioServicio>();
builder.Services.AddScoped<ComercioRepositorio>();


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
