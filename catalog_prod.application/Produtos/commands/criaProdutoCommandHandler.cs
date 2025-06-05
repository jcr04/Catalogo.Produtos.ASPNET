using FluentValidation;
using catalog_prod.domain.entities;
using catalog_prod.domain.interfaces;
using MediatR;
using static catalog_prod.application.Produtos.commands.CriarProdutoCommands;

namespace catalog_prod.application.Produtos.commands;

public class criaProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Guid>
{
    private readonly IProdutoRepoitory _repository;
    private readonly IValidator<CriarProdutoCommand> _validator;

    public criaProdutoCommandHandler(IProdutoRepoitory repository, IValidator<CriarProdutoCommand> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Guid> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            var errors = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }

        var product = new Produto
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ImageUrl = request.ImageUrl
        };

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}
