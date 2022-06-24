using NLayerCore.DTOs;
using NLayerCore.Models;
using SharedLibrary.DTOs;
using System.Linq.Expressions;

namespace NLayerCore.Services
{
    public interface IProductFeatureService<ProductFeature, ProductFeatureDto> : IGenericService<ProductFeature, ProductFeatureDto> where ProductFeatureDto : class where ProductFeature : class
    {
        Task<Response<ProductFeatureDto>> AddAsync(int id, ProductFeatureDto entity);

    }
}