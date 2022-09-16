using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;
using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Aggregates
{
    public class BasketAggregateState : AggregateState
    {
        public void When(BasketCreatedEvent @event)
        {
            new BasketRecord()
            {
                CreatedDate = DateTime.Now,
                BasketId = @event.BasketId
            };
        }
    }
}
