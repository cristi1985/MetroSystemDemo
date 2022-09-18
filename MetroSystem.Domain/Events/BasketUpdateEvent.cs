using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public class BasketUpdateEvent : Event
    {
        public Guid AggregateIdentifier { get; set; }
        public long AggregateVersion { get; set; }
        public Guid BasketId { get; set; }
        public string BuyerName { get; set; }
        public long EventTime { get; set; }
        public string EventType { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
     
        
    }
}
