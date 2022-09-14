using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Utilities;


namespace MetroSystem.API.Stores
{
    public class EventStore : IEventStore<BasketAggregate, BasketAggregateState>
    {
        public ISerializer Serializer => throw new NotImplementedException();

        public Task Box(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Guid aggregateIdentifier, int version)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get<T>(Guid aggregateIdentifier, int version) where T : IEvent
        {
            throw new NotImplementedException();
        }

        public Task<BasketAggregate> GetAggregate(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetExpired(long at)
        {
            throw new NotImplementedException();
        }

        public Task Save(BasketAggregate aggregate, IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
