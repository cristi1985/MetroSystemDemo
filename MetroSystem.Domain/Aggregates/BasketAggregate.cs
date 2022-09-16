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
        public Guid AggregateIdentifier { get; set; }
        public string AggregateClass { get; set; }
        public string AggregateType { get; set; }

        public override BasketAggregateState CreateState() => new();
        
        public BasketCreatedEvent CreateBasket(string customerName)
        {
            var @event = new BasketCreatedEvent
            {
                BasketId = Guid.NewGuid(),
                BuyerName = customerName
            };
            Apply(@event);
            return @event;
        }
    }
}
