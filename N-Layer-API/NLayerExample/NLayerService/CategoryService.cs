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
    public class CategoryService
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(AppDbContext context, IGenericRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryDtos = categories.Select(p => new CategoryDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            if (!categoryDtos.Any())
            {
                return new Response<List<CategoryDto>>()
                {
                    Data = null,
                    Errors = new List<string> { "Kategori mevcut değildir! " },
                    Status = 404
                };
            }

            return new Response<List<CategoryDto>>()
            {
                Data = categoryDtos,
                Errors = null,
                Status = 200
            };
        }

        public async Task<Response<CategoryDto>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return new Response<CategoryDto>()
                {
                    Data = null,
                    Errors = new List<string> { "Kategori mevcut değildir! " },
                    Status = 404
                };
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };

            return new Response<CategoryDto>()
            {
                Data = categoryDto,
                Errors = null,
                Status = 200
            };

        }

        public async Task<Response<string>> Create(CategoryDto categoryDto)
        {
            var category = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Products = new List<Product>()
            };
            await categoryRepository.Add(category);
            await unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }

        public async Task<Response<string>> Update(int id, CategoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return new Response<string>() { Errors = new List<string> { "Kategori mevcut değildir! " }, Status = 404 };
            category.Name = categoryDto.Name != default ? categoryDto.Name : category.Name;
            await unitOfWork.Commit();
            return new Response<string>() { Status = 200 };
        }

        public Response<string> Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (category is null)
                return new Response<string> { Errors = new List<string> { "Kategori mevcut değildir! " }, Status = 404 };
            categoryRepository.Delete(category);
            unitOfWork.Commit();
            return new Response<string> { Status = 200 };
        }
    }
}
