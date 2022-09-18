using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Models
{
    public class BasketRecord
    {
        public Guid BasketId { get; internal set; }
        public DateTime CreatedDate { get; internal set; }


    }
}
