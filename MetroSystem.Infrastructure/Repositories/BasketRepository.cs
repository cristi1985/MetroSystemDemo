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
               [BuyerName],
               [PaysVat],
               [Closed],
               [Payed]
            )
            VALUES (
                @BasketId,
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
                    @event.BuyerName
                }, transaction);
                transaction.Commit();

                return new BasketGridDto()
                {
                    BasketId = @event.BasketId,
                    BuyerName = @event.BuyerName
                };
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
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
