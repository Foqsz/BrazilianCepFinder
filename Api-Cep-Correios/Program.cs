using Api_Cep_Correios.Controllers;
using Api_Cep_Correios.Services;
using Api_Cep_Correios.Services.Interfaces;
using Api_Cep_Correios.Services.Refit;
using Microsoft.OpenApi.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>

        c.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "BuscaCepAPI",
            Description = "Api de Busca via CEP",
            TermsOfService = new Uri("https://foqsz.github.io/"),
            Contact = new OpenApiContact
            {
                Name = "Victor Vinicius",
                Email = "contatovictorvinicius05@gmail.com",
                Url = new Uri("https://foqsz.github.io/"),
            },
            License = new OpenApiLicense
            {
                Name = "Usar sobre LICX",
                Url = new Uri("https://foqsz.github.io/"),
            }
}));

builder.Services.AddScoped<IBuscaCepIntegracao, BuscaCepIntegracacao>();

builder.Services.AddRefitClient<IBuscaCepIntegracaoRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br/ws/");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
