using catalog_prod.domain.entities;
using catalog_prod.domain.interfaces;
using catalog_prod.infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Prod.Infra.Repositories;

public class ProdutoRepository : IProdutoRepoitory
{
    private readonly CatalogDbContext _context;

    public ProdutoRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Produto product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}
