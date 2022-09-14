using MetroSystem.Domain.Aggregates;
using MetroSystem.Domain.Events;
using MetroSystem.Domain.Utilities;
using MetroSystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace MetroSystem.API.Stores
{ 
    public class BasketEventStore : IBasketEventStore
    {
        private readonly DapperContext _context;
        public ISerializer Serializer { get; }
        public BasketEventStore(DapperContext context)
        {
            _context = context;
            Serializer = new StoreSerializer();
        }

        public Task Box(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exists(Guid aggregateIdentifier)
        {
            using var connection = _context.CreateConnection();
            connection.Open();

            var query =
                "SELECT 1 FROM Basket WHERE BasketId = :aggregateIdentifier";
            connection.BeginTransaction();
            return (await connection.QueryAsync(query, new { aggregateIdentifier = aggregateIdentifier })).Any();
        }

        public Task<bool> Exists(Guid aggregateIdentifier, int version)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get<T>(Guid aggregateIdentifier, int version) where T : IEvent
        {
            throw new NotImplementedException();
        }

        public Task<BasketAggregate> GetAggregate(Guid aggregateIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetExpired(long at)
        {
            throw new NotImplementedException();
        }

        public Task Save(BasketAggregate aggregate, IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
