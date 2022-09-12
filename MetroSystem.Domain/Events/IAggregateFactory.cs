using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetroSystem.Domain.Events
{
    public interface IAggregateFactory<TAggregate, TState> where TAggregate:AggregateRoot<TState> where TState : AggregateState
    {
        TAggregate CreateAggregate();
    }
}
