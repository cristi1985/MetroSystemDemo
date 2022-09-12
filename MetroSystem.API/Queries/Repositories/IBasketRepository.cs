using MetroSystem.Domain.Events;
using MetroSystem.Infrastructure.Queries.Repositories;

namespace MetroSystem.API.Queries.Repositories
{
    public interface IBasketRepository
    {
        public Task<BasketGridDto> CreateBasket(BasketCreatedEvent @event);
    }
}
