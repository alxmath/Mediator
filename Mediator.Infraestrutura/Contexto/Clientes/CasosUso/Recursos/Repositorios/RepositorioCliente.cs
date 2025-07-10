using Mediator.Dominio.Contextos.Clientes.CasosUso.Recursos.Repositorios;
using Mediator.Dominio.Contextos.Clientes.Entidades;

namespace Mediator.Infraestrutura.Contexto.Clientes.CasosUso.Recursos.Repositorios;

public class RepositorioCliente : IRepositorioCliente
{
    public async Task<Cliente> ObterPorIdAsync(int id, CancellationToken ct)
    {
        Console.WriteLine($"Obtendo cliente com ID: {id}");

        await Task.Delay(1000, ct);
        
        return new Cliente
        {
            Id = id,
            Name = $"Cliente {id}"
        };
    }
}