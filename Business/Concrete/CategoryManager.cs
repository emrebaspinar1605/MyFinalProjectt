using Business.Abstract;
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

        public void Add(Category category)
        {
            _cDal.Add(category);
        }

        public void Delete(Category category)
        {
            _cDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _cDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _cDal.Get(c => c.CategoryId == id);
        }

        public void Update(Category category)
        {
            _cDal.Update(category);
        }
    }
}
