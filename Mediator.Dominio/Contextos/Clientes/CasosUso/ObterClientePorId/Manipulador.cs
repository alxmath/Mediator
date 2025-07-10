using Mediator.Abstractions;
using Mediator.Dominio.Contextos.Clientes.CasosUso.Recursos.Repositorios;
using Mediator.Dominio.Contextos.Clientes.Entidades;

namespace Mediator.Dominio.Contextos.Clientes.CasosUso.ObterClientePorId;

public class Manipulador(IRepositorioCliente repositorio) 
    : IHandler<Requisicao, Cliente>
{
    public async Task<Cliente> HandleAsync(Requisicao request, 
        CancellationToken cancellationToken = default)
    {
        return await repositorio.ObterPorIdAsync(request.IdCliente, cancellationToken);
    }
}