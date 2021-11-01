using Core.DataAccess;
using Entities.Concrete;
using Entities.Model;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieDal:IEntityRepository<Movie>
    {
        List<Movie> GetAll();
        Movie Get(int id);
    }
}
