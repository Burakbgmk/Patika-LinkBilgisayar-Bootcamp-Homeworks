using ApiWeb.Entities;
using ApiWeb.ProductOperations.CreateProduct;
using ApiWeb.ProductOperations.GetProductInfo;
using ApiWeb.ProductOperations.GetProducts;
using ApiWeb.ProductOperations.UpdateProduct;
using AutoMapper;

namespace ApiWeb.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie, MovieInfoViewModel>();
            CreateMap<Movie, MoviesViewModel>();
        }
    }
}
