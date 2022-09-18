using MetroSystem.Domain.Events;
using MetroSystem.Domain.Models;
using MetroSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MetroSystem.Domain.Aggregates
{
    public class BasketAggregateState : AggregateState
    {
        public Guid BasketId { get; set; }
        public string BuyerName { get; set; }

        public string ItemName { get; set; }
        public decimal Price { get; set; }  
        public void When(BasketCreatedEvent @event)
        {
            if (@event.BasketId != null || @event.BasketId != new Guid())
            {
                BasketId = @event.BasketId;
                BuyerName = @event.BuyerName;
            }
            else
            {
                new BasketRecord()
                {
                    CreatedDate = DateTime.Now,
                    BasketId = @event.BasketId
                };
            }
            
        }
        public void When(SerializedEvent @event)
        {
            if(@event.EventType == nameof(BasketCreatedEvent))
            {
                var eventObject = JsonConvert.DeserializeObject<BasketCreatedEvent>(@event.EventData);
                When(eventObject);
            }
        } 

        public void When (BasketUpdateEvent @event)
        {
            BasketId = @event.BasketId;
            BuyerName = @event.BuyerName;
            ItemName = @event.Item;
            Price = @event.Price;

        }
        


    }
}
