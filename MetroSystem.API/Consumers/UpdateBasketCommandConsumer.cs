using MassTransit;
using MassTransit.Mediator;
using MetroSystem.API.Commands;
using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;

namespace MetroSystem.API.Consumers
{
    public class UpdateBasketCommandConsumer : BaseCommandLocalConsumerShared<BasketAggregate, BasketAggregateState>, IConsumer<UpdateBaskeCommand>
    {
        private readonly IBasketRepository _basketrepository;
        private readonly IBasketAggregateFactory _basketaggregatefactory;

        public UpdateBasketCommandConsumer(IEventRepository<BasketAggregate, BasketAggregateState> eventRepository, 
            IMediator mediator,
            IBasketRepository basketrepository,
            IBasketAggregateFactory basketaggregatefactory) : base(eventRepository, mediator)
        {   
            _basketrepository = basketrepository;
            _basketaggregatefactory = basketaggregatefactory;   
        }

        public async Task Consume(ConsumeContext<UpdateBaskeCommand>context)
        {
            try
            {
                var aggregate = await GetAggregate(context.Message.BasketId);
                Console.WriteLine("xxxx");
                //await GetAggregate(context.)
            }
            catch (Exception ex)
            {

            }
        }
    }
}
