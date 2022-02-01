using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Mediator.Arguments;
using Web.Mediator.Requests;

namespace Web.Controllers;

[Route("[controller]")]
public class AdminController : Controller
{

    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var carProducts = await _mediator.Send(new ShowRequest(new()));

        return View(new AdminViewModel(carProducts));
    }
        
    [HttpDelete]
    public IActionResult Delete(string mark, string model)
    {
        _mediator.Send(new RemoveRequest(new RemoveRequestArguments(mark, model)));

        return Ok();
    }

    [HttpPost]
    public IActionResult Add([FromForm] AddRequestArguments arguments)
    {
        _mediator.Send(new AddRequest(arguments));

        return RedirectToAction("Index");
    }
}