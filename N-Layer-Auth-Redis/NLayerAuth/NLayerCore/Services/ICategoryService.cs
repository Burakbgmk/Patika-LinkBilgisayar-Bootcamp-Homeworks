using NLayerCore.DTOs;
using NLayerCore.Models;
using SharedLibrary.DTOs;
using System.Linq.Expressions;

namespace NLayerCore.Services
{
    public interface ICategoryService<Category,CategoryDto> : IGenericService<Category,CategoryDto> where CategoryDto : class where Category : class
    {
        
    }
}