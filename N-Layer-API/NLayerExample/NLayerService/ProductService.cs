using Microsoft.EntityFrameworkCore;
using NLayerData;
using NLayerData.Models;
using NLayerService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<ProductFeature> productFeatureRepository;

        private readonly IUnitOfWork unitOfWork;
        

        public ProductService(AppDbContext context, IGenericRepository<Product> productRepository, IGenericRepository<ProductFeature> productFeatureRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.productRepository = productRepository;
            this.productFeatureRepository = productFeatureRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProductDto>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            var productDtos = products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            if (!productDtos.Any())
            {
                return new Response<List<ProductDto>>()
                {
                    Data = null,
                    Errors = new List<string> { "Ürün mevcut değildir! " },
                    Status = 404
                };
            }

            return new Response<List<ProductDto>>()
            {
                Data = productDtos,
                Errors = null,
                Status = 200
            };
        }

        public async Task<Response<ProductDto>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product is null)
                return new Response<ProductDto>()
                {
                    Data = null,
                    Errors = new List<string> { "Ürün mevcut değildir! " },
                    Status = 404
                };
            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
                
            return new Response<ProductDto>()
            {
                Data = productDto,
                Errors = null,
                Status = 200
            };

        }

        public async Task<Response<string>> Create(ProductDto productDto)
        {
            await CreateProduct(productDto);

            return new Response<string>() { Status = 200 };
        }


        public async Task<Response<string>> CreateWithFeatures(ProductDto productDto, ProductFeatureDto productFeatureDto)
        {
            using(var transaction = unitOfWork.BeginTransaction())
            {
                var productId = await CreateProduct(productDto);
                await CreateFeature(productId, productFeatureDto);
                transaction.Commit();
            }
            return new Response<string>() { Status = 200 };
        }
        public async Task<Response<string>> Update(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id); 
            if(product is null)
                return new Response<string>() { Errors = new List<string> { "Ürün mevcut değildir! " }, Status = 404 };
            product.Name = productDto.Name != default ? productDto.Name : product.Name;
            product.Price = productDto.Price != default ? productDto.Price : product.Price;
            product.CategoryId = productDto.CategoryId != default ? productDto.CategoryId : product.CategoryId;
            
            await unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }

        public Response<string> Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if(product is null)
                return new Response<string> { Errors = new List<string> { "Ürün mevcut değildir! " }, Status = 404 };
            productRepository.Delete(product);
            unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }

        public async Task<Response<List<ProductFullModel>>> GetFullModel()
        {

            var fullProductList = "sp_full_products";

            var list = await  _context.ProductFullModels.FromSqlInterpolated($"exec {fullProductList}").ToListAsync();

            return new Response<List<ProductFullModel>>() { Data = list, Status = 200 };

        }

        public async Task<Response<List<ProductFullModel>>> GetFullModelWithFunction()
        {
            var list = await _context.ProductFullModels.ToListAsync();

            return new Response<List<ProductFullModel>>() { Data = list, Status = 200 };

        }

        //CreateWithFeature için kullanılan komutlar
        #region 
        private async Task<int> CreateProduct(ProductDto productDto)
        {
            var categories = await _context.Categories.ToListAsync();
            var productFeature = await _context.ProductFeatures.ToListAsync();
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Stock = 2,
                Category = categories.Find(x => x.Id == productDto.CategoryId),
                ProductFeature = productFeature.Find(x => x.Id == productDto.Id)
            };
            await productRepository.Add(product);
            await unitOfWork.Commit();
            return product.Id;
        }

        private async Task CreateFeature(int id, ProductFeatureDto productFeatureDto)
        {
            var product = await _context.Products.FindAsync(id);
            var productFeature = new ProductFeature()
            {
                Id = id,
                Width = productFeatureDto.Width,
                Height = productFeatureDto.Height,
                Product = product
            };
            await productFeatureRepository.Add(productFeature);
            await unitOfWork.Commit();
        }
        #endregion

    }
}
