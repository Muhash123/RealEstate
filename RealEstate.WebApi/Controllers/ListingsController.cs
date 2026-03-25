using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Listings.Commands;
using RealEstate.Application.Listings.Queries;

namespace RealEstate.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
// Используем первичный конструктор для внедрения Mediator
public class ListingsController(IMediator mediator) : ControllerBase
{
    // 1. Получить все объявления
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllListingsQuery());
        return Ok(result);
    }

    // 2. Получить одно по ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetListingByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    // 3. Создать новое
    [HttpPost]
    public async Task<IActionResult> Create(CreateListingCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    // 4. Обновить существующее
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateListingCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");

        var result = await mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    // 5. Удалить
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteListingCommand(id));
        return result ? NoContent() : NotFound();
    }
}