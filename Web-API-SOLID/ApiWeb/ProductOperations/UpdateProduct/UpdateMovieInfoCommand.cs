namespace ApiWeb.ProductOperations.UpdateProduct
{
    public class UpdateMovieInfoCommand
    {
        private readonly ProductContext _dbContext;

        public int MovieId { get; set; }

        public UpdateMovieModel Model { get; set; }

        public UpdateMovieInfoCommand(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("No movie found to be updated!");
            movie.Title = Model.Title != default ? Model.Title : movie.Title;
            movie.Genre = Model.Genre != default ? Model.Genre : movie.Genre;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
