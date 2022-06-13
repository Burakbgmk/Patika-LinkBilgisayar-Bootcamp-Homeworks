namespace ApiWeb.ProductOperations.DeleteProduct
{
    public class DeleteMovieCommand
    {
        private readonly ProductContext _dbContext;
        public int MovieId { get; set; }

        public DeleteMovieCommand(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("No movie found to be deleted!");
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }

}
