using Mediator.Dominio.Contextos.Clientes.Entidades;

namespace Mediator.Dominio.Contextos.Clientes.CasosUso.Recursos.Repositorios;

public interface IRepositorioCliente
{
    Task<Cliente> ObterPorIdAsync(int id, CancellationToken ct);
}