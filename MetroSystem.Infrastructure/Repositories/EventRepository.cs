using MetroSystem.Domain.Events;
using MetroSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Infrastructure.Repositories
{
    public class BasketEventRepository<TAggregate, TEvent, TState> : IEventRepository<TAggregate, TState>
        where TEvent:IEvent
        where TAggregate : AggregateRoot<TState>
        where TState : AggregateState
    {
        private readonly IEventStore<TAggregate, TState> _store;
        private readonly IServiceProvider _serviceProvider;

        public BasketEventRepository(IEventStore<TAggregate, TState> store, IServiceProvider serviceProvider)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets an aggregate from the event store.
        /// </summary>
        public Task<TAggregate> Get(Guid aggregate)
        {
            return Rehydrate(aggregate);
        }

        /// <summary>
        /// Gets an aggregate from the event store until the specified version.
        /// </summary>
        public Task<TAggregate> Get(Guid aggregate, int version)
        {
            return Rehydrate(aggregate, version);
        }

        /// <summary>
        /// Saves all uncommitted changes to the event store.
        /// </summary>
        public async Task<IEvent[]> Save(TAggregate aggregate, int? version)
        {
            if (version != null && (await _store.Exists(aggregate.AggregateIdentifier, version.Value)))
                throw new ConcurrencyException(aggregate.AggregateIdentifier);

            // Get the list of events that are not yet saved. 
            var events = aggregate.FlushUncommittedChanges();

            // Save the uncommitted changes.
            await _store.Save(aggregate, events);

            // The event repository is not responsible for publishing these events. Instead they are returned to the 
            // caller for that purpose.
            return events;
        }

        /// <summary>
        /// Loads an aggregate instance from the full history of events for that aggreate.
        /// </summary>
        private async Task<TAggregate> Rehydrate(Guid id, int version = -1)
        {
            //Check that id of basket exists first
            bool basketExists = await _store.Exists(id);
            if (basketExists)
            {
                // Get all the events for the aggregate.
                var events = await _store.Get<TEvent>(id, version);

                // Disallow empty event streams.
                if (!events.Any())
                    throw new AggregateNotFoundException(typeof(TAggregate), id);

                // Create and load the aggregate.
                // var factory = _serviceProvider.GetService<IAggregateFactory<TAggregate, TState>>();

                var aggregate = await _store.GetAggregate(events.Select(x => x.AggregateIdentifier).FirstOrDefault());
                if (aggregate == null)
                {
                    throw new Exception($"Unable to find aggregate of type {typeof(TAggregate)}");
                }
                aggregate.Rehydrate(events);

                return aggregate;
            }
            return null;
           
        }
    }
}
