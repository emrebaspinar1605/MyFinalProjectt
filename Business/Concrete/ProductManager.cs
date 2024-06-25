using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _pDal;
        ICategoryService _cService;
        public ProductManager(IProductDal pDal, ICategoryService cService)
        {
            _pDal = pDal;
            _cService = cService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            IResult results = BusinessRules.Run(CheckProductNameIsValid(product),
                  CheckMaxLimitOfProductInCategory(product.CategoryID), CheckCategoryCount());
            if (results != null)
            {
                return results;
            }


            _pDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {



            return new SuccessDataResult<List<Product>>(_pDal.GetAll(), Messages.ProductListed);
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckProductNameIsValid(product),
                 CheckMaxLimitOfProductInCategory(product.CategoryID), CheckCategoryCount());
            if (result != null)
            {
                return result;
            }

            _pDal.Update(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        #region BusinessRulesMethods

        private IResult CheckMaxLimitOfProductInCategory(int catID)
        {
            if (_pDal.GetAll(p => p.CategoryID == catID).Count >= 10)
                return new ErrorResult(Messages.MaxLimitOfProductInCategory);
            return new SuccessResult();
        }
        private IResult CheckProductNameIsValid(Product product)
        {
            var result = _pDal.GetAll(p => p.ProductName == product.ProductName && p.ProductID != product.ProductID);
            if (result.Any())
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()
        {

            var result = _cService.GetAll();

            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.MaxCategoryLimit);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
