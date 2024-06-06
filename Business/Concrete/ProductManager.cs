using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            if (product.ProductName?.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _pDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            
            return new SuccessDataResult<List<Product>>(_pDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_pDal.GetAll(p => p.CategoryID == id), Messages.ProductListedByCategoryId);

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_pDal.Get(p => p.ProductID == productId), Messages.ProductGetById);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_pDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProductListedByUnitPrice);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_pDal.GetProductDetails(), Messages.ProductDetailListed);
        }
    }
}
