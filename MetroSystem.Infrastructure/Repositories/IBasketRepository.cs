using MetroSystem.Domain.Events;

using MetroSystem.Infrastructure.Dto;

namespace MetroSystem.Domain.Models
{
    public interface IBasketRepository
    {
        public Task<BasketGridDto> CreateBasket(BasketCreatedEvent @event);

        public Task<BasketGridDto> UpdateBasket (BasketUpdateEvent @event);
    }
}
