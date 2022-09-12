using MetroSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroSystem.Domain.Events
{
    public abstract class AggregateRoot<TState> where TState : AggregateState
    {
        /// <summary>
        /// Changes to the state of the aggregate that are not yet committed to a persistent event store.
        /// </summary>
        private readonly List<IEvent> _changes = new();

        /// <summary>
        /// Represents the state (i.e. data/packet) for the aggregate.
        /// </summary>
        public TState State { get; set; }

        /// <summary>
        /// Uniquely identifies the aggregate.
        /// </summary>
        public Guid AggregateIdentifier { get; set; }

        /// <summary>
        /// Current version of the aggregate.
        /// </summary>
        public int AggregateVersion { get; set; }

        /// <summary>
        /// Every aggregate must override this method to create the object that holds its current state.
        /// </summary>
        public abstract TState CreateState();

        /// <summary>
        /// Returns all uncommitted changes. 
        /// </summary>
        /// <returns></returns>
        public IEvent[] GetUncommittedChanges()
        {
            lock (_changes)
            {
                return _changes.ToArray();
            }
        }

        /// <summary>
        /// Returns all uncommitted changes and clears them from the aggregate.
        /// </summary>
        public IEvent[] FlushUncommittedChanges()
        {
            lock (_changes)
            {
                var changes = _changes.ToArray();

                var i = 0;

                foreach (var change in changes)
                {
                    if (change.AggregateIdentifier == Guid.Empty && AggregateIdentifier == Guid.Empty)
                        throw new MissingAggregateIdentifierException(GetType(), change.GetType());

                    if (change.AggregateIdentifier == Guid.Empty)
                        change.AggregateIdentifier = AggregateIdentifier;
                    else
                        AggregateIdentifier = change.AggregateIdentifier;

                    i++;

                    change.AggregateVersion = AggregateVersion + i;
                    change.EventTime = DateTime.Now.ToFileTimeUtc();
                }

                AggregateVersion += changes.Length;

                _changes.Clear();

                return changes;
            }
        }

        /// <summary>
        /// Loads an aggregate from a stream of events.
        /// </summary>
        public void Rehydrate<TEvent>(IEnumerable<TEvent> history) where TEvent : IEvent
        {
            lock (_changes)
            {
                foreach (var change in history.ToArray())
                {
                    try
                    {
                        if (change.AggregateVersion != AggregateVersion + 1)
                            throw new UnorderedEventsException(change.AggregateIdentifier);

                        ApplyEvent(change);

                        AggregateIdentifier = change.AggregateIdentifier;
                        AggregateVersion++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unable to apply event {change.GetType()} - Exception: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Applies a change to the aggregate state AND appends the event to the history of uncommited changes.
        /// </summary>
        protected void Apply(IEvent change)
        {
            lock (_changes)
            {
                ApplyEvent(change);
                _changes.Add(change);
            }
        }

        /// <summary>
        /// Applies a change to the aggregate state. This method is called internally when rehydrating an aggregate, 
        /// and you can override this when custom handling is needed.
        /// </summary>
        protected virtual void ApplyEvent(IEvent change)
        {
            State ??= CreateState();

            State.Apply(change);
        }
    }
}
