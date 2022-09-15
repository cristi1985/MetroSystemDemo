using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public class SerializedEvent : IEvent
    {
        public Guid AggregateIdentifier { get ; set; }
        public long AggregateVersion { get ; set ; }
        public long EventTime { get; set ; }
        public string EventClass { get; set; }

        public string EventType { get; set; }

        public string EventData { get; set; }

        public SerializedEvent()
        {
            EventTime = DateTime.Now.ToBinary();
        }

    }
}
