using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _cDal;

        public CategoryManager(ICategoryDal cDal)
        {
            _cDal = cDal;
        }

        public Result Add(Category category)
        {
            _cDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public Result Delete(Category category)
        {
            _cDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_cDal.GetAll(), Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_cDal.Get(c => c.CategoryId == id),Messages.CategoryGetById);
        }

        public Result Update(Category category)
        {
            _cDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _cDal;

        public CustomerManager(ICustomerDal cDal)
        {
            _cDal = cDal;
        }
    }
}
