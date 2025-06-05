using catalog_prod.domain.entities;
using MediatR;

namespace catalog_prod.application.Produtos.Queries;

public class GetProductsQuery : IRequest<List<Produto>>
{
}