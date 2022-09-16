using MassTransit;
using MassTransit.Mediator;
using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Commands;
using MetroSystem.API.Consumers;
using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroSystem.Domain.Models;

namespace MetroSystem.API.Consumers
{
    public class CreateBasketCommandConsumer  : BaseCommandLocalConsumerShared<BasketAggregate, BasketAggregateState>, IConsumer<CreateBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketAggregateFactory _basketAggregateFactory;

        public CreateBasketCommandConsumer(IEventRepository<BasketAggregate, BasketAggregateState> eventRepository,
       IBasketRepository basketRepository,
       IBasketAggregateFactory basketAggregateFactory,
       IMediator mediator) : base(eventRepository, mediator)
        {
            _basketRepository = basketRepository;
            _basketAggregateFactory = basketAggregateFactory;
        }

        public async Task Consume(ConsumeContext<CreateBasketCommand> context)
        {
            try
            {
                var aggregate = _basketAggregateFactory.CreateAggregate();
                BasketCreatedEvent @event = aggregate.CreateBasket(context.Message.CustomerName);
                await Save(aggregate, @event);

                await context.RespondAsync<IBasketCreationResult>(new BasketCreationResult
                {
                    IsSuccessful = true,
                    BasketId = @event.BasketId
                });


            }
            catch(Exception ex)
            {
                await context.RespondAsync(CommandResult.Error(ex.Message));
            }
        }
    }

       
    

}

