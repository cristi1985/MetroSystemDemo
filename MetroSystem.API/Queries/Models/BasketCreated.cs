namespace MetroSystem.API.Queries.Models
{
    public class BasketCreated:IBasketCreated
    {
        public Guid BasketId { get; set; }
        public string BuyerName { get; set; }
    }
}
