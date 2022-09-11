namespace Shared.Timeline.Events
{
    public interface IEventRepository<TAggregate, TState> where TAggregate : AggregateRoot<TState>
        where TState : AggregateState
    {

    }
}