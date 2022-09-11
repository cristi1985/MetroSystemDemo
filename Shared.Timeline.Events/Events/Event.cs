using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Timeline.Events
{
    public class Event : IEvent
    {
        public Guid AggregateIdentifier { get; set; }
        public long AggregateVersion { get; set; }
        public long EventTime { get; set; }
    }
}
