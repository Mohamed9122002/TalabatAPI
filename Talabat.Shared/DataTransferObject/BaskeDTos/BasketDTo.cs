using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Shared.DataTransferObject.BaskeDTos
{
    public class BasketDTo
    {
        public string Id { get; set; }
        public ICollection<BasketItemDTo> Items { get; set; } 
    }
}
