using ApiWeb.Entities;
using AutoMapper;

namespace ApiWeb.ProductOperations.CreateProduct
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }

        private readonly ProductContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(ProductContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);
            if (movie is not null)
                throw new InvalidOperationException("Movie already exists");

            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
