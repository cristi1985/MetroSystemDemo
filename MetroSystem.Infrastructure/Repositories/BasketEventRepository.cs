using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Infrastructure.Repositories
{
    public class BasketEventRepository : EventRepository<BasketAggregate, SerializedEvent, BasketAggregateState>, IBasketEventRepository
    {
        public BasketEventRepository(IBasketEventStore store, IServiceProvider serviceProvider) : base(store, serviceProvider)
        {
        }
    }
}
