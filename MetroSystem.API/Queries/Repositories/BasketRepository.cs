using MetroSystem.Domain.Events;
using MetroSystem.Infrastructure.Queries.Repositories;

namespace MetroSystem.API.Queries.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Task<BasketGridDto> CreateBasket(BasketCreatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
