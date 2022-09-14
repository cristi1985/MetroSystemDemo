using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Exceptions
{
    [Serializable]
    public class UnorderedEventsException:Exception
    {
        public UnorderedEventsException(Guid aggregate)
           : base($"The events for this aggregate are not in the expected order ({aggregate}).")
        {
        }

        protected UnorderedEventsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
