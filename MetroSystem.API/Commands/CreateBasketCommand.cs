using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.API.Commands
{
    public class CreateBasketCommand
    {
        public string CustomerName { get; set; }
        public bool PaysVat { get; set; }
    }
}
