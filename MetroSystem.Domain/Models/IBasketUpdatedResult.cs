using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Models
{
    public interface IBasketUpdatedResult : ICommandResult
    {
       Guid BasketId { get; set; }
    }
}
