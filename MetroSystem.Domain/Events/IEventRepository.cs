namespace MetroSystem.Domain.Events
{
    public interface IEventRepository<TAggregate, TState> where TAggregate : AggregateRoot<TState>
        where TState : AggregateState
    {
        /// </summary>
        Task<TAggregate> Get(Guid id);

        /// <summary>
        /// Returns the aggregate identified by the specified id and rehydrated until specified version.
        /// </summary>
        Task<TAggregate> Get(Guid id, int version);

        /// <summary>
        /// Saves an aggregate.
        /// </summary>
        /// <returns>
        /// Returns the events that are now saved (and ready to be published).
        /// </returns>
        Task<IEvent[]> Save(TAggregate aggregate, int? version = null);

      
    }
}