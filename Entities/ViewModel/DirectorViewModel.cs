using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class DirectorViewModel:IViewModel
    {
        public string FullName { get; set; }
        public List<string> DirectedMovies { get; set; }
    }
}
