using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.Performer
{
    public class UpdatePerformerModel:IModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
