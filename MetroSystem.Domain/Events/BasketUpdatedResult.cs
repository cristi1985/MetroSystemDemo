using MetroSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Events
{
    public class BasketUpdatedResult : CommandResult, IBasketUpdatedResult
    {
        public Guid BasketId { get; set; }
    }
}
