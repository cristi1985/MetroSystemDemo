using MetroSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    internal class AggregateFactory<T>
    {
        private static readonly Func<T> Constructor = CreateTypeConstructor();

        internal static T CreateAggregate()
        {
            if (Constructor == null)
                throw new MissingDefaultConstructorException(typeof(T));

            return Constructor();
        }

        private static Func<T> CreateTypeConstructor()
        {
            try
            {
                var expr = Expression.New(typeof(T));

                var func = Expression.Lambda<Func<T>>(expr);

                return func.Compile();
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
