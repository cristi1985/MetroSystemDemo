using MetroSystem.Infrastructure.Queries.Repositories;
using MetroSystem.Domain.Events;

namespace MetroSystem.Infrastructure.Queries
{
    public interface IBasketRepository
    {
        public Task<BasketGridDto> CreateBasket(BasketCreatedEvent @event);
    }
}
