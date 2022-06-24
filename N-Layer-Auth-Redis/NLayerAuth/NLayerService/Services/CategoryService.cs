using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayerCore.DTOs;
using NLayerCore.Models;
using NLayerCore.Repositories;
using NLayerCore.Services;
using NLayerCore.UnitOfWork;
using NLayerData;
using SharedLibrary.DTOs;


namespace NLayerService.Services
{
    public class CategoryService : GenericService<Category,CategoryDto>, ICategoryService<Category,CategoryDto>
    {
        //private readonly AppDbContext _context;
        //private readonly IGenericRepository<Category> categoryRepository;
        //private readonly IUnitOfWork unitOfWork;
        //private readonly IMemoryCache memoryCache;

        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository) : base(unitOfWork, genericRepository)
        {
            
        }

        //public CategoryService(AppDbContext context, IGenericRepository<Category> categoryRepository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        //{
        //    _context = context;
        //    this.categoryRepository = categoryRepository;
        //    this.unitOfWork = unitOfWork;
        //    this.memoryCache = memoryCache;
        //}

        //public async Task<Response<List<CategoryDto>>> GetAll()
        //{
        //    var categoryDtos = memoryCache.Get<List<CategoryDto>>("categoryDtos");
        //    if (categoryDtos == null)
        //    {
        //        var categories = await _context.Categories.ToListAsync();
        //        categoryDtos = categories.Select(p => new CategoryDto()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //        }).ToList();
        //        memoryCache.Set("categoryDtos", categoryDtos, TimeSpan.FromSeconds(10));
        //    }
        //    if (!categoryDtos.Any())
        //    {
        //        return new Response<List<CategoryDto>>()
        //        {
        //            Data = null,
        //            Errors = new List<string> { "Kategori mevcut değildir! " },
        //            Status = 404
        //        };
        //    }
        //    return new Response<List<CategoryDto>>()
        //    {
        //        Data = categoryDtos,
        //        Errors = null,
        //        Status = 200
        //    };
        //}

        //public async Task<Response<CategoryDto>> GetById(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category is null)
        //        return new Response<CategoryDto>()
        //        {
        //            Data = null,
        //            Errors = new List<string> { "Kategori mevcut değildir! " },
        //            Status = 404
        //        };
        //    var categoryDto = new CategoryDto()
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //    };

        //    return new Response<CategoryDto>()
        //    {
        //        Data = categoryDto,
        //        Errors = null,
        //        Status = 200
        //    };

        //}

        //public async Task<Response<string>> Create(CategoryDto categoryDto)
        //{
        //    var category = new Category()
        //    {
        //        Id = categoryDto.Id,
        //        Name = categoryDto.Name,
        //        Products = new List<Product>()
        //    };
        //    await categoryRepository.Add(category);
        //    await unitOfWork.Commit();
        //    return new Response<string>() { Status = 200 };
        //}

        //public async Task<Response<string>> Update(int id, CategoryDto categoryDto)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category is null)
        //        return new Response<string>() { Errors = new List<string> { "Kategori mevcut değildir! " }, Status = 404 };
        //    category.Name = categoryDto.Name != default ? categoryDto.Name : category.Name;
        //    await unitOfWork.Commit();
        //    return new Response<string>() { Status = 200 };
        //}

        //public Response<string> Delete(int id)
        //{
        //    var category = _context.Categories.SingleOrDefault(x => x.Id == id);
        //    if (category is null)
        //        return new Response<string> { Errors = new List<string> { "Kategori mevcut değildir! " }, Status = 404 };
        //    categoryRepository.Delete(category);
        //    unitOfWork.Commit();
        //    return new Response<string> { Status = 200 };
        //}
    }
}
