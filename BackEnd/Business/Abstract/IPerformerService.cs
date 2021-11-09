using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Model.Performer;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPerformerService
    {
        IDataResult<List<PerformerViewModel>> GetAll();
        IDataResult<PerformerViewModel> GetById(int id);
        IResult Add(AddPerformerModel model);
        IResult Update(int id, UpdatePerformerModel model);
        IResult Delete(int id);
    }
}
