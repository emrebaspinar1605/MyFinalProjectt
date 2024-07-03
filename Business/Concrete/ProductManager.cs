using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Business.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;

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
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

            IResult result = BusinessRules.Run(CheckClaimIsCorrect(),CheckProductNameIsValid(product ),
                  CheckMaxLimitOfProductInCategory(product.CategoryID), CheckCategoryCount());
            if (result != null)
                return new ErrorResult(result.Message);

            _pDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }
        [CacheAspect]
        //[TransactionScopeAspect]
        public IDataResult<List<Product>> GetAll()
        {



            return new SuccessDataResult<List<Product>>(_pDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_pDal.GetAll(p => p.CategoryID == id), Messages.ProductListedByCategoryId);

        }
        [CacheAspect]
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
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckClaimIsCorrect(),CheckProductNameIsValid(product),
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
        private IResult CheckClaimIsCorrect()
        {
            if (SecuredOperation.trueRole) return new SuccessResult();

            return new ErrorResult(Messages.AuthorizationDenied);
                    
        }
        #endregion
    }
}
