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
using MetroSystem.Domain.Models;

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
                "SELECT 1 FROM Basket WHERE BasketId = @aggregateIdentifier";
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

        public async Task Save(BasketAggregate aggregate, IEnumerable<IEvent> events)
        {
            var list = new List<SerializedEvent>();

            foreach (var e in events)
            {
                var item = e.Serialize(Serializer, aggregate.AggregateIdentifier, e.AggregateVersion);
                list.Add(item);
            }

            var insertEventStatement = @"INSERT INTO [dbo].[BasketEvents] 
                (
                    [AggregateIdentifier],
                    [AggregateVersion],
                    [EventTime],
                    [EventType],
                    [EventData]
                )
                VALUES (
                    @aggregateIdentifier,
                    @aggregateVersion,
                    @EventTime,
                    @EventType,
                    @EventData)";

            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            await EnsureAggregateExists(connection, transaction, aggregate);

            try
            {
                foreach (var @event in list)
                {
                    await connection.ExecuteAsync(insertEventStatement, new
                    {
                        @event.AggregateIdentifier,
                        @event.AggregateVersion,
                        @event.EventTime,
                        @event.EventType,
                        @event.EventData,
                    }, transaction);

                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private async Task EnsureAggregateExists(IDbConnection connection, IDbTransaction transaction,  BasketAggregate aggregate)
        {
            var existsQuery =
                "SELECT 1 FROM BasketAggregates WHERE AGGREGATEIDENTIFIER = @aggregateIdentifier";

            var envoiceAggregates = await connection.QueryAsync(existsQuery, new { aggregateIdentifier = aggregate.AggregateIdentifier }, transaction);
            if (envoiceAggregates.Any()) return;

            var insertStatement = @"
                INSERT INTO [dbo].[BasketAggregates] (
                    [AGGREGATEIDENTIFIER],
                    [AGGREGATECLASS],
                    [AGGREGATETYPE]
                )
                VALUES
                (
                    @aggregateIdentifier,
                    @aggregateClass,
                    @aggregateType
                )";

            var type = aggregate.GetType();
            await connection.ExecuteAsync(insertStatement, new
            {
                aggregateIdentifier = aggregate.AggregateIdentifier,
                aggregateClass = type.FullName,
                aggregateType = type.Name.Replace("Aggregate", string.Empty),
            }, transaction);
        }
    }
}
