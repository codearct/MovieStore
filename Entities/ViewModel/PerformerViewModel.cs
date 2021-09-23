using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class PerformerViewModel:IViewModel
    {
        public string FullName { get; set; }
        public List<string> StarringMovies { get; set; }
    }
}
