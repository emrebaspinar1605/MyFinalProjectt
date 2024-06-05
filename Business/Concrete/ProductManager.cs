using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _pDal;

        public ProductManager(IProductDal pDal)
        {
            _pDal = pDal;
        }

        public List<Product> GetAll()
        {

            return _pDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _pDal.GetAll(p => p.CategoryID == id);

        }

        public Product GetById(int id)
        {
            return _pDal.Get(p => p.ProductID == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _pDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            return _pDal.GetProductDetails();
        }
    }
}
