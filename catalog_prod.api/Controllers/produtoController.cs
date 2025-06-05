using catalog_prod.application.Produtos.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static catalog_prod.application.Produtos.commands.CriarProdutoCommands;

namespace catalog_prod.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class produtoController : ControllerBase
{
    private readonly IMediator _mediator;

    public produtoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CriarProdutoCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }
}
