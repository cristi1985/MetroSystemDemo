using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public interface IEvent
    {
        Guid AggregateIdentifier { get; set; }
        long AggregateVersion { get; set; }
        long EventTime { get; set; }
    }
}
