using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.PerformerValidator;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Model.Performer;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PerformerManager : IPerformerService
    {
        IPerformerDal _performerDal;
        IMapper _mapper;

        public PerformerManager(IPerformerDal performerDal, IMapper mapper)
        {
            _performerDal = performerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddPerformerModelValidator))]
        public IResult Add(AddPerformerModel model)
        {
            var performer = _performerDal.Get(p => p.Name == model.Name && p.Surname == model.Surname);

            IResult result = BusinessRules.Run(CheckIfPerformerAlreadyExists(performer));
            if (result != null)
            {
                return result;
            }

            performer = _mapper.Map<Performer>(model);

            _performerDal.Add(performer);

            return new SuccessResult(Messages.PerformerAdded);
        }

        public IResult Delete(int id)
        {
            var performer = _performerDal.Get(p=>p.Id==id);

            IResult result = BusinessRules.Run(CheckIfPerformerNotExist(performer));
            if (result != null)
            {
                return result;
            }

            _performerDal.Delete(performer);

            return new SuccessResult(Messages.DeletedPerformer);
        }

        public IDataResult<List<PerformerViewModel>> GetAll()
        {
            var performers = _performerDal.GetAll();

            List<PerformerViewModel> performerVMs = _mapper.Map<List<PerformerViewModel>>(performers);

            return new SuccessDataResult<List<PerformerViewModel>>(performerVMs);
        }

        public IDataResult<PerformerViewModel> GetById(int id)
        {
            var performer = _performerDal.Get(p=>p.Id==id);

            if (performer is null)
            {
                return new ErrorDataResult<PerformerViewModel>(Messages.NotExistPerformer);
            }

            PerformerViewModel performerVM = _mapper.Map<PerformerViewModel>(performer);

            return new SuccessDataResult<PerformerViewModel>(performerVM);
        }

        [ValidationAspect(typeof(UpdatePerformerModelValidator))]
        public IResult Update(int id, UpdatePerformerModel model)
        {
            var performer = _performerDal.GetById(id);

            var result = BusinessRules.Run(CheckIfPerformerNotExist(performer));
            if (result != null)
            {
                return result;
            }

            performer.Name = string.IsNullOrEmpty(model.Name) ? performer.Name : model.Name;
            performer.Surname = string.IsNullOrEmpty(model.Surname) ? performer.Surname : model.Surname;

            _performerDal.Update(performer);

            return new SuccessResult(Messages.UpdatedPerformer);
        }

        private IResult CheckIfPerformerAlreadyExists(Performer performer)
        {
            if (performer is not null)
            {
                return new ErrorResult(Messages.ExistingPerformer);
            }
            return new SuccessResult();
        }
        private IResult CheckIfPerformerNotExist(Performer performer)
        {
            if (performer is null)
            {
                return new ErrorResult(Messages.NotExistPerformer);
            }
            return new SuccessResult();
        }
    }
}
