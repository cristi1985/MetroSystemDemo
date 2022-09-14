using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroSystem.Domain.Utilities;

namespace MetroSystem.Domain.Events
{
    public interface IEventStore<TAggregate, TState>
        where TAggregate : AggregateRoot<TState>
        where TState: AggregateState
    {
        /// <summary>
        /// Utility for serializing and deserializing events.
        /// </summary>
        ISerializer Serializer { get; }

        /// <summary>
        /// Returns true if an aggregate exists.
        /// </summary>
        Task<bool> Exists(Guid aggregateIdentifier);

        /// <summary>
        /// Returns true if an aggregate with a specific version exists.
        /// </summary>
        Task<bool> Exists(Guid aggregateIdentifier, int version);

        /// <summary>
        /// Returns aggregate header
        /// </summary>
        /// <param name="aggregateIdentifier"></param>
        /// <returns></returns>
        Task<TAggregate> GetAggregate(Guid aggregateIdentifier);

        /// <summary>
        /// Gets events for an aggregate starting at a specific version. To get all events use version = -1.
        /// </summary>
        Task<IEnumerable<T>> Get<T>(Guid aggregateIdentifier, int version) where T : IEvent;

        /// <summary>
        /// Gets all aggregates that are scheduled to expire at (or before) a specific time on a specific date.
        /// </summary>
        Task<IEnumerable<Guid>> GetExpired(long at);

        /// <summary>
        /// Save events.
        /// </summary>
        Task Save(TAggregate aggregate, IEnumerable<IEvent> events);

        /// <summary>
        /// Copies an aggregate to offline storage and removes it from online logs.
        /// </summary>
        /// <remarks>
        /// Someone who is a purist with regard to event sourcing will red-flag this function and say the event stream 
        /// for an aggregate should never be altered or removed. However, we have two scenarios in which this is a non-
        /// negotiable business requirement. First, when a customer does not renew their contract with our business, we
        /// have a contractual obligation to remove all the customer's data from our systems. Second, we frequently run
        /// test-cases to confirm system functions are operating correctly; this data is temporary by definition, and 
        /// we do not want to permanently store the event streams for test aggregates.
        /// </remarks>
        Task Box(Guid aggregateIdentifier);

        /// <summary>
        /// Deletes an aggregate and its events -- Dangerous in production
        /// </summary>
        /// <param name="aggregateIdentifier"></param>
        Task<int> Delete(Guid aggregateIdentifier);
    }
}
