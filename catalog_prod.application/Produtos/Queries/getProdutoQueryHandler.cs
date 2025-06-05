using catalog_prod.domain.entities;
using catalog_prod.domain.interfaces;
using MediatR;

namespace catalog_prod.application.Produtos.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Produto>>
{
    private readonly IProdutoRepoitory _repository;

    public GetProductsQueryHandler(IProdutoRepoitory repository)
    {
        _repository = repository;
    }

    public async Task<List<Produto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}
