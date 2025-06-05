using catalog_prod.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace catalog_prod.infra.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<Produto> Products { get; set; }
}