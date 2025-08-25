public interface IMovieRepository
{
    void AddMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(int id);
    IEnumerable<Movie> GetMoviesByYear(int year);
    IEnumerable<Movie> GetMoviesByDirector(string directorName);
}
