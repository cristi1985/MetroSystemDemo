using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Model
{
    public class BasketRecord
    {
        public Guid RecordIdentifier { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductNumber { get; set; }


    }
}
