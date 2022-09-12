using MassTransit.Mediator;
using MetroSystem.Domain.Events;

namespace MetroSystem.API.Consumers
{
    public class BaseCommandLocalConsumerShared<TAggregate, TAggregateState>
        where TAggregate : AggregateRoot<TAggregateState>
        where TAggregateState : AggregateState
    {
        protected readonly IEventRepository<TAggregate, TAggregateState> EventRepository;
        protected readonly IMediator Mediator;


        public BaseCommandLocalConsumerShared(
          IEventRepository<TAggregate, TAggregateState> eventRepository,
          IMediator mediator
          )
        {
            EventRepository = eventRepository;
            Mediator = mediator;
         
        }

        public Task<TAggregate> GetAggregate(Guid aggregate)
        {
            return EventRepository.Get(aggregate);
        }

        protected async Task Save(TAggregate aggregate, Event @event)
        {
            try
            {
                           
                await EventRepository.Save(aggregate);
                await Mediator.Send(@event);
             
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
    }
}
