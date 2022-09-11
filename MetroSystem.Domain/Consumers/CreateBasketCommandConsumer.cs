using MassTransit;
using MassTransit.Mediator;
using MetroSystem.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Consumers
{
    public class CreateBasketCommandConsumer(IEventRepository<BasketAggregate, BasketAggregateState> eventRepository,
        IMediator mediator):IConsumer<CreateBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketValidatorFactory _validatorFactory;
    
    public CreateBasketCommandConsumer(IBasketRepository<BasketAggregate, BasketAggregateState> eventRepository,
        IBasketRepository basketRepository,
        IBasketValidatorFactory, validatorFactory,
        IMediator mediator)
    {
        _basketRepository = basketRepository;
        _validatorFactory = validatorFactory
    }
}

