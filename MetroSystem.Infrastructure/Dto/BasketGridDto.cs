namespace MetroSystem.Infrastructure.Dto
{
    public class BasketGridDto
    {

        public Guid BasketId { get; set; }
        public Guid AggregateIdentifier { get; set; }
        public string BuyerName { get; set; }
        public string Products { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalGross { get; set; }
        public bool PaysVat { get; set; }
        public bool Closed { get; set; }
        public bool Payed { get; set; }
        
    }
}
