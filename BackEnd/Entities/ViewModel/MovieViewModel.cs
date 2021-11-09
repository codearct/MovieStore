using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class MovieViewModel:IViewModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<string> Performers { get; set; }
    }
}
