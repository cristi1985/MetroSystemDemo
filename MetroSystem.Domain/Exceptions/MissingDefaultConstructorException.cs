using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Exceptions
{
    [Serializable]
    public class MissingDefaultConstructorException : Exception
    {
        public MissingDefaultConstructorException(Type type)
          : base($"This class has no default constructor ({type.FullName}).")
        {
        }

        protected MissingDefaultConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
