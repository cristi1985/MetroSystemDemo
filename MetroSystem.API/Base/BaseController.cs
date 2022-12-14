using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MassTransit.Mediator;
using MetroSystem.Domain.Models;

namespace MetroSystem.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> Logger;
        protected readonly IMediator Mediator;

        public BaseController(ILogger<BaseController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        protected async Task<ActionResult> GetCommandResultResponse<T>(T query) where T: class
        {
            var client = Mediator.CreateRequestClient<T>();
            var response = await client.GetResponse<CommandResult>(query).ConfigureAwait(false);
            return response.Message?.IsSuccessful == true
                   ? new OkObjectResult(response.Message) : new BadRequestObjectResult(response.Message);
        }
    }
}
