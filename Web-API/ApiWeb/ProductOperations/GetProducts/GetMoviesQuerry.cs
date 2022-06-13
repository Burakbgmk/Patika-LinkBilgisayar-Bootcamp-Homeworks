using ApiWeb.Entities;
using AutoMapper;

namespace ApiWeb.ProductOperations.GetProducts
{
    public class GetMoviesQuerry : IGetMovies
    {
        private readonly ProductContext _dbContext;
        private readonly IMapper _mapper;


        public GetMoviesQuerry(ProductContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(x => x.Id).ToList();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
