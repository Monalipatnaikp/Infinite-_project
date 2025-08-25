public class MovieRepository : IMovieRepository
{
    private readonly MoviesDbContext _context;

    public MovieRepository(MoviesDbContext context)
    {
        _context = context;
    }

    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }

    public void DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Movie> GetMoviesByYear(int year)
    {
        return _context.Movies.Where(m => m.DateofRelease.Year == year).ToList();
    }

    public IEnumerable<Movie> GetMoviesByDirector(string directorName)
    {
        return _context.Movies
            .Where(m => m.DirectorName.Equals(directorName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
