using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.Director
{
    public class AddDirectorModel:IModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
