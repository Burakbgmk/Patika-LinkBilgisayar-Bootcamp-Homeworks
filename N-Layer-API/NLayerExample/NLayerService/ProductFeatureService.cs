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
    public class ProductFeatureService
    {
        private readonly AppDbContext _context;

        private readonly IGenericRepository<ProductFeature> productFeatureRepository;

        private readonly IUnitOfWork unitOfWork;

        public ProductFeatureService(AppDbContext context, IGenericRepository<ProductFeature> productFeatureRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.productFeatureRepository = productFeatureRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<ProductFeatureDto>> GetById(int id)
        {
            var pf = await _context.ProductFeatures.FindAsync(id);
            if (pf is null)
                return new Response<ProductFeatureDto>()
                {
                    Data = null,
                    Errors = new List<string> { "Ürün Özelliği mevcut değildir! " },
                    Status = 404
                };
            var productFeatureDto = new ProductFeatureDto()
            {
                Id = pf.Id,
                Width = pf.Width,
                Height = pf.Height
            };

            return new Response<ProductFeatureDto>()
            {
                Data = productFeatureDto,
                Errors = null,
                Status = 200
            };

        }

        public async Task<Response<string>> Create(int id, ProductFeatureDto productFeatureDto)
        {
            var product = await _context.Products.FindAsync(id);
            var pf = await _context.ProductFeatures.FindAsync(id);
            if (pf is not null)
                return new Response<string>() { Errors = new List<string>() { "Ürün özelliği zaten mevcut" },Status = 404 };
            else if(product is null)
                return new Response<string>() { Errors = new List<string>() { "Eklenecek ürün mevcut değildir" }, Status = 404 };
            var productFeature = new ProductFeature()
            {
                Id = id,
                Width = productFeatureDto.Width,
                Height = productFeatureDto.Height,
                Product = product
            };
            await productFeatureRepository.Add(productFeature);
            await unitOfWork.Commit();

            return new Response<string>() { Status = 200 };
        }

        public async Task<Response<string>> Update(int id, ProductFeatureDto productFeatureDto)
        {
            var pf = await _context.ProductFeatures.FindAsync(id);
            if (pf is null)
                return new Response<string>() { Errors = new List<string>() { "Ürün özelliği mevcut değil" }, Status = 404 };
            pf.Width = productFeatureDto.Width != default ? productFeatureDto.Width : pf.Width;
            pf.Height = productFeatureDto.Height != default ? productFeatureDto.Height : pf.Height;

            await unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }

        public Response<string> Delete(int id)
        {
            var pf = _context.ProductFeatures.Find(id);
            if (pf is null)
                return new Response<string>() { Errors = new List<string>() { "Ürün özelliği mevcut değil" }, Status = 404 };
            
            productFeatureRepository.Delete(pf);
            unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }
    }
}
