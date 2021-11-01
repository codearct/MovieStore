using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Model.Director;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        IDataResult<List<DirectorViewModel>> GetAll();
        IDataResult<DirectorViewModel> GetById(int id);
        IResult Add(AddDirectorModel model);
        IResult Update(int id, UpdateDirectorModel model);
        IResult Delete(int id);
    }
}
