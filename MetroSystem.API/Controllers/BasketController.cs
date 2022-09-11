using MassTransit.Mediator;
using MetroSystem.API.Base;
using MetroSystem.Domain.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetroSystem.API.Controllers
{
    public class BasketController : BaseController
    {
        public BasketController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("createbasket")]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketCommand command )
        {
            return await GetCommandResultResponse(command);
        }
    }
}
