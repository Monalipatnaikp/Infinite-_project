[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _repo;

    public MoviesController(IMovieRepository repo)
    {
        _repo = repo;
    }

    [HttpPost("add")]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _repo.AddMovie(movie);
        return Ok("Movie added successfully");
    }

    [HttpPut("edit")]
    public IActionResult EditMovie([FromBody] Movie movie)
    {
        _repo.UpdateMovie(movie);
        return Ok("Movie updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteMovie(int id)
    {
        _repo.DeleteMovie(id);
        return Ok("Movie deleted successfully");
    }

    [HttpGet("year/{year}")]
    public IActionResult GetMoviesByYear(int year)
    {
        var movies = _repo.GetMoviesByYear(year);
        return Ok(movies);
    }

    [HttpGet("director/{name}")]
    public IActionResult GetMoviesByDirector(string name)
    {
        var movies = _repo.GetMoviesByDirector(name);
        return Ok(movies);
    }
}
