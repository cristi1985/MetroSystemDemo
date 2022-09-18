namespace MetroSystem.API.Queries.Models
{
    public class BasketUpdated:IBasketUpdated
    {
        public Guid BasketId { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
