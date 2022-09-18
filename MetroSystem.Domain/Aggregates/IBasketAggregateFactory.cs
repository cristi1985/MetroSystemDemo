using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroSystem.Domain.Events;

namespace MetroSystem.Domain.Aggregates
{
    public interface IBasketAggregateFactory: IAggregateFactory<BasketAggregate, BasketAggregateState>
    {
        BasketAggregate CreateAggregate(Guid aggregateidentifier);
    }
}
