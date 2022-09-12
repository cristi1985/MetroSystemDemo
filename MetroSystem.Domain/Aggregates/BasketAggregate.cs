using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Aggregates
{
    public class BasketAggregate : AggregateRoot<BasketAggregateState>
    {
        public override BasketAggregateState CreateState() => new();
        
        public BasketCreatedEvent CreateBasket(string customerName)
        {
            var @event = new BasketCreatedEvent
            {
                BasketId = Guid.NewGuid(),
                CustomerName = customerName
            };
            Apply(@event);
            return @event;
        }
    }
}
