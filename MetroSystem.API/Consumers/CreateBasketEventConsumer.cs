using MassTransit;
using MassTransit.Mediator;
using MetroSystem.API.Queries.Models;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;

namespace MetroSystem.API.Consumers
{
    public class CreateBasketEventConsumer:IConsumer<BasketCreatedEvent>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketEventConsumer(IBasketRepository basketRepository)   
        {
            _basketRepository = basketRepository;
        }

        public async Task Consume(ConsumeContext<BasketCreatedEvent> context)
        {
            var basket = await _basketRepository.CreateBasket(context.Message);
            await context.RespondAsync<IBasketCreated>(new BasketCreated
            {
                BasketId = context.Message.BasketId,
                BuyerName = context.Message.BuyerName
            });

            //await _bus.Publish<IBasketCreated>(new BasketCreated
            //{
            //    BasketId = context.Message.BasketId,
            //    BuyerName = context.Message.BuyerName,
            //}); 
        }
    }
}
