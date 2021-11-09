using Core.DataAccess;
using Entities.Concrete;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPerformerDal:IEntityRepository<Performer>
    {
        List<Performer> GetAll();
        Performer GetById(int id);
    }
}
