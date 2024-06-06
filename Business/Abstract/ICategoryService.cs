using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        Result Add(Category category);
        Result Update(Category category);
        Result Delete(Category category);
        IDataResult<Category> GetById(int id);
    }
}
