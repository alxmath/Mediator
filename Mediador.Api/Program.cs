using Mediator.Abstractions;
using Mediator.Dominio;
using Mediator.Dominio.Contextos.Clientes.CasosUso.ObterClientePorId;
using Mediator.Dominio.Contextos.Clientes.CasosUso.Recursos.Repositorios;
using Mediator.Infraestrutura.Contexto.Clientes.CasosUso.Recursos.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();

builder.Services.AddOpenApi();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/clientes/{id:int}", async (IMediator mediator, int id) =>
{
    var requisicao = new Requisicao(id);
    var result = await mediator.SendAsync(requisicao);
    
    return Results.Ok(result);
});



app.Run();