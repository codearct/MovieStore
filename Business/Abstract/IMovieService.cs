using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Model;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<MovieViewModel>> GetAll();
        IDataResult<MovieViewModel> GetById(int id);
        IDataResult<Movie> Get(int id);
        IResult Add(AddMovieModel model);
        IResult Update(int id, UpdateMovieModel model);
        IResult Delete(int id);
    }
}
