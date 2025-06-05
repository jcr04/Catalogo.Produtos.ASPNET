using catalog_prod.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog_prod.domain.interfaces;

public interface IProdutoRepoitory
{
    Task AddAsync(Produto product, CancellationToken cancellationToken);
    Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken);
}
