using MassTransit;
using MetroSystem.API.Queries.Models;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;

namespace MetroSystem.API.Consumers
{
    public class UpdateBasketEventConsumer : IConsumer<BasketUpdateEvent>
    {
        private readonly IBasketRepository _basketRespository;

        public UpdateBasketEventConsumer(IBasketRepository basketRespository)
        {
            _basketRespository = basketRespository;
        }

        public async Task Consume(ConsumeContext<BasketUpdateEvent> context)
        {
            var basket = await _basketRespository.UpdateBasket(context.Message);

            await context.RespondAsync<IBasketUpdated>( new BasketUpdated
            { 
                BasketId = context.Message.BasketId,
                IsSuccessful = true
           

            });
        }
    }
}
