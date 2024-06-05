using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            // Normalde veriler db'den gelir.
            _products = new List<Product>
            {
              new Product{ProductID = 1,CategoryID = 1, ProductName = "Bardak",UnitPrice = 15, UnitsInStock = 27},
              new Product{ProductID = 2,CategoryID = 2, ProductName = "kamera",UnitPrice = 500, UnitsInStock = 22},
              new Product{ProductID = 3,CategoryID = 2, ProductName = "Telefon",UnitPrice = 1500, UnitsInStock = 10},
              new Product{ProductID = 4,CategoryID = 3, ProductName = "Masa",UnitPrice = 150, UnitsInStock = 25},
              new Product{ProductID = 5,CategoryID = 3, ProductName = "Yatak",UnitPrice = 85, UnitsInStock = 4},

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product? productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product? productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            if (productToUpdate != null)
            {
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryID = product.CategoryID;
            }
        }
    }
}
