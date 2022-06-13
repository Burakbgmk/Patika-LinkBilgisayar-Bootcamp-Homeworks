using ApiWeb.ProductOperations.GetProducts;
using AutoMapper;

namespace ApiWeb.ProductOperations.GetProductInfo
{
    public class GetMovieInfoQuerry
    {
        private readonly ProductContext _dbContext;
        private readonly IMapper _mapper;

        public int MovieId { get; set; }

        public GetMovieInfoQuerry(ProductContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieInfoViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(x => x.Id == MovieId).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("Movie is not found!");
            MovieInfoViewModel vm = _mapper.Map<MovieInfoViewModel>(movie);
            return vm;
        }
    }

    public class MovieInfoViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
