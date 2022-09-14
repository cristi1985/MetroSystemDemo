using MetroSystem.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public interface IBasketEventStore : IEventStore<BasketAggregate, BasketAggregateState>
    {
    }
}
