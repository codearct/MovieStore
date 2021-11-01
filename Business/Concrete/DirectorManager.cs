using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.DirectorValidator;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Model.Director;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        IDirectorDal _directorDal;
        IMapper _mapper;

        public DirectorManager(IDirectorDal directorDal, IMapper mapper)
        {
            _directorDal = directorDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddDirectorModelValidator))]
        public IResult Add(AddDirectorModel model)
        {
            var director = _directorDal.Get(d => d.Name == model.Name && d.Surname == model.Surname);

            IResult result = BusinessRules.Run(CheckIfDirectorAlreadyExists(director));
            if (result != null)
            {
                return result;
            }

            director = _mapper.Map<Director>(model);

            _directorDal.Add(director);

            return new SuccessResult(Messages.DirectorAdded);
        }

        public IResult Delete(int id)
        {
            var director = _directorDal.Get(d => d.Id == id);

            IResult result = BusinessRules.Run(CheckIfDirectorNotExists(director));
            if (result is not null)
            {
                return result;
            }

            _directorDal.Delete(director);

            return new SuccessResult(Messages.DeletedDirector);
        }
        

        public IDataResult<List<DirectorViewModel>> GetAll()
        {
            var directors = _directorDal.GetAll();

            List<DirectorViewModel> directorVMs = _mapper.Map<List<DirectorViewModel>>(directors);

            return new SuccessDataResult<List<DirectorViewModel>>(directorVMs);
        }

        public IDataResult<DirectorViewModel> GetById(int id)
        {
            var director = _directorDal.Get(d => d.Id == id);

            if (director is null)
            {
                return new ErrorDataResult<DirectorViewModel>(Messages.NotExistDirector);
            }

            DirectorViewModel directorVM = _mapper.Map<DirectorViewModel>(director);

            return new SuccessDataResult<DirectorViewModel>(directorVM);

        }

        [ValidationAspect(typeof(UpdateDirectorModelValidator))]
        public IResult Update(int id, UpdateDirectorModel model)
        {
            var director = _directorDal.Get(d => d.Id == id);

            IResult result = BusinessRules.Run(CheckIfDirectorNotExists(director));
            if (result is not null)
            {
                return result;
            }

            director.Name = string.IsNullOrEmpty(model.Name) ? director.Name : model.Name;
            director.Surname = string.IsNullOrEmpty(model.Surname) ? director.Surname : model.Surname;

            return new SuccessResult(Messages.UpdatedDirector);
        }

        private IResult CheckIfDirectorAlreadyExists(Director director)
        {
            if (director is not null)
            {
                return new ErrorResult(Messages.ExistingDirector);
            }
            return new SuccessResult();
        }
        private IResult CheckIfDirectorNotExists(Director director)
        {
            if (director is null)
            {
                return new ErrorResult(Messages.NotExistDirector);
            }

            return new SuccessResult();
        }
    }
}
