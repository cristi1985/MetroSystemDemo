using MetroSystem.Domain.Events;
using MetroSystem.Infrastructure.Dto;
using MetroSystem.Infrastructure.Context;
using Dapper;

namespace MetroSystem.Domain.Models
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DapperContext _context;

        public BasketRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<BasketGridDto> CreateBasket(BasketCreatedEvent @event)
        {
            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            var createBasketStatement = @"INSERT INTO [dbo].[Basket]
            (
               [BasketId],
               [AggregateIdentifier],
               [BuyerName],
               [PaysVat],
               [Closed],
               [Payed]
            )
            VALUES (
                @BasketId,
                @AggregateIdentifier,
                @BuyerName,
                1,
                0,
                0
        )";
        
            try
            {
                await connection.ExecuteAsync(createBasketStatement, new
                {
                    @event.BasketId,
                    @event.AggregateIdentifier,
                    @event.BuyerName
                }, transaction);
                transaction.Commit();

                return new BasketGridDto()
                {
                    BasketId = @event.BasketId,
                    AggregateIdentifier = @event.AggregateIdentifier,
                    BuyerName = @event.BuyerName
                };
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex.InnerException);
            }
         
        }

        public async Task<BasketGridDto> UpdateBasket (BasketUpdateEvent @event)
        {
            decimal PricePlusVat = Decimal.Add(Decimal.Multiply(@event.Price, (decimal)0.19), @event.Price);
            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            var updateBasketStatement = @"Update [dbo].[Basket] SET
            [Products] = @Products,
            [TotalNet] = @TotalNet,
            [TotalGross] = @TotalGross,
            [PaysVat] = @Paysvat,
            [Closed] = @Closed,
            [Payed] = @Payed
            WHERE BasketId = @BasketId";

            try
            {
                await connection.ExecuteAsync(updateBasketStatement, new
                {
                    Products = @event.Item,
                    TotalNet = PricePlusVat ,
                    TotalGross = @event.Price,
                    PaysVat = true,
                    Closed = false,
                    Payed = false,
                    BasketId = @event.BasketId

                }, transaction);
                transaction.Commit();

                return new BasketGridDto()
                {
                    BasketId = @event.BasketId,
                    AggregateIdentifier = @event.AggregateIdentifier,
                    BuyerName = @event.BuyerName
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public Guid BasketId { get; set; }
        public string BuyerName { get; set; }
        public string Products { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalGross { get; set; }
        public bool PaysVat { get; set; }
        public bool Closed { get; set; }
        public bool Payed { get; set; }
    }
}
