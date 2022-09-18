using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Aggregates
{
    public class BasketAggregateFactory : IBasketAggregateFactory
    {
        public BasketAggregate CreateAggregate()
        {
            return new() { AggregateIdentifier = Guid.NewGuid() };
        }

        public BasketAggregate CreateAggregate(Guid aggregateIdentifier)
        {
            return new() { AggregateIdentifier = aggregateIdentifier }; 
        }
    }
}
