using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Exceptions
{
    [Serializable]
    public class AggregateNotFoundException:Exception
    {
        public AggregateNotFoundException(Type type, Guid id)
           : base($"This aggregate does not exist ({type.FullName} {id}) because there are no events for it.")
        {
        }

        protected AggregateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
