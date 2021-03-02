using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // Business codes

            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); // MaintenanceTime=BakımZamanı
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int produtId)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == produtId), true, "DEFAULT SUCCESS...");
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), true, "SUCCESS");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            try
            {
                return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), "Error...");
            }
        }
    }
}
