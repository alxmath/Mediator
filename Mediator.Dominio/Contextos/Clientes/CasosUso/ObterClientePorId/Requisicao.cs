using Mediator.Abstractions;
using Mediator.Dominio.Contextos.Clientes.Entidades;

namespace Mediator.Dominio.Contextos.Clientes.CasosUso.ObterClientePorId;

public record Requisicao(int IdCliente) : IRequest<Cliente>; 
