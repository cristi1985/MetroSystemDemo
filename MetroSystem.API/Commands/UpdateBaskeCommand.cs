namespace MetroSystem.API.Commands
{
    public class UpdateBaskeCommand
    {
        public Guid BasketId { get; set; }
        public string Item { get; set; }    
        public decimal Price { get; set; }
    }
}
