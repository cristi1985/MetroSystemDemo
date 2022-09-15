using MetroSystem.Domain.Events;
using MetroSystem.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Models
{
    public static class EventExtensions
    {
        public static SerializedEvent Serialize(this IEvent @event, ISerializer serializer, Guid aggregateIdentifier, long version)
        {
            var data = serializer.Serialize(@event, new[] { "AggregateIdentifier", "AggregateVersion", "EventTime",  "EventClass", "EventType", "EventData" });

            var serialized = new SerializedEvent
            {
                AggregateIdentifier = aggregateIdentifier,
                AggregateVersion = version,

                EventTime = @event.EventTime,
                EventClass = @event.GetType().AssemblyQualifiedName,
                EventType = @event.GetType().Name,
                EventData = data,

            };

            return serialized;
        }
    }
}
