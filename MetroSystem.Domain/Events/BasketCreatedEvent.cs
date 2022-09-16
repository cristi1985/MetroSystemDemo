using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public class BasketCreatedEvent : Event
    {
        public Guid RecordIdentifier { get; set; }
        public Guid BasketId { get; set; }
        public string BuyerName { get; set; }

    }
}
