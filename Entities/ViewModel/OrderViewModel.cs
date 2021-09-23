using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class OrderViewModel:IViewModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public string PurchaseDate { get; set; }
        public int MoviePrice { get; set; }
    }
}
