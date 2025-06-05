using FluentValidation;
using static catalog_prod.application.Produtos.commands.CriarProdutoCommands;

namespace catalog_prod.application.Produtos.commands;

public class CriarProdutoCommandValidator : AbstractValidator<CriarProdutoCommand>
{
    public CriarProdutoCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório")
            .MaximumLength(80).WithMessage("O nome deve ter no máximo 80 caracteres");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descrição obrigatória")
            .MaximumLength(300).WithMessage("A descrição deve ter no máximo 300 caracteres");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Preço deve ser maior que zero");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Informe a URL da imagem");
    }
}
