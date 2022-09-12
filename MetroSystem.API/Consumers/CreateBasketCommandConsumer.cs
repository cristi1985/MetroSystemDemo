using MassTransit;
using MassTransit.Mediator;
using MetroSystem.API.Queries.Repositories;
using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Commands;
using MetroSystem.API.Consumers;
using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Consumers
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

        public Task Consume(ConsumeContext<CreateBasketCommand> context)
        {
            throw new NotImplementedException();
        }
    }

       
    

}

