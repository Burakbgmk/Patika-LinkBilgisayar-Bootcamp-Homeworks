using NLayerCore.Models;
using NLayerCore.DTOs;
using SharedLibrary.DTOs;
using System.Linq.Expressions;

namespace NLayerCore.Services
{
    public interface IProductService<Product, ProductDto> : IGenericService<Product, ProductDto> where ProductDto : class where Product : class
    {
        Task<Response<NoDataDto>> CreateWithFeatures(ProductDto productDto, ProductFeatureDto productFeatureDto);
        
        Task<Response<List<ProductFullModel>>> GetFullModel();
        Task<Response<List<ProductFullModel>>> GetFullModelWithFunction();
        //Task<int> CreateProduct(ProductDto productDto);
        //Task CreateFeature(int id, ProductFeatureDto productFeatureDto);
    }
}