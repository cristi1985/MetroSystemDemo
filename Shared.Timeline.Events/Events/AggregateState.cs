using Shared.Timeline.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Timeline.Events
{
    public abstract class AggregateState
    {
        public void Apply(IEvent @event)
        {
            try
            {
                var when = GetType().GetMethod("When", new[] { @event.GetType() });
                if(when == null)
                {
                    throw new MethodNotFoundException(GetType(), "When", @event.GetType());
                }
                when.Invoke(this, new object[] {@event});
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
