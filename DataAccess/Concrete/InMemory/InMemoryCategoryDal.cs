using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;
        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category{ CategoryId = 1, CategoryName = "Mutfak Ürünleri"},
                new Category{ CategoryId = 2, CategoryName = "Elektronik"},
                new Category{ CategoryId = 3, CategoryName = "Mobilya"}
            };
        }
        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            Category? categoryToDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);

            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            Category? categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = category.CategoryName;
            }
        }
    }
}
