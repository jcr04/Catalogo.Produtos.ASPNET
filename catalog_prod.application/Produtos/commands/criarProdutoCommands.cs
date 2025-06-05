using MediatR;

namespace catalog_prod.application.Produtos.commands;

public class CriarProdutoCommands
{
    public record CriarProdutoCommand(string Name, string Description, decimal Price, string ImageUrl) : IRequest<Guid>;
}
