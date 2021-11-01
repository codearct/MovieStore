using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MoviePerformer:IEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}
