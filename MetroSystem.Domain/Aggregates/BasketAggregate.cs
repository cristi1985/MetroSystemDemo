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

        public BasketUpdateEvent UpdateBasket (Guid aggregateIdentifier, Guid basketId, string itemName, decimal price )
        {
            var @event = new BasketUpdateEvent
            {
                AggregateIdentifier = aggregateIdentifier,
                AggregateVersion = 1,
                BasketId= basketId,
                Item = itemName,
                Price = price
            };
            Apply(@event);
            return @event;
        }
    }
}
