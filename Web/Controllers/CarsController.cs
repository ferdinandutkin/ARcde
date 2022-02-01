using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Mediator.Arguments;
using Web.Mediator.Requests;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("/")]
    [Route("[controller]")]
    public class CarsController : Controller
    {

        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public  async Task<IActionResult> Index()
        {
            var carProducts = await _mediator.Send(new ShowRequest(new ()));

            return View(new IndexViewModel(carProducts));
        }

       
        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromForm] BuyRequestArguments arguments)
        {
            await _mediator.Send(new BuyRequest(arguments));
            return RedirectToAction("Index");
        }

        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromForm] SellRequestArguments arguments)
        {
            await _mediator.Send(new SellRequest(arguments));
            return RedirectToAction("Index");
        }



        [HttpGet("models/{mark}")]
        public async Task<IActionResult> GetModels(string mark)
        {
            var models = await _mediator.Send(new GetModelsRequest(new(mark)));
            return Json(models);
        }


    }
}
