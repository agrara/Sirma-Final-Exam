using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AnalysisController : ControllerBase
{
    private readonly AppDbContext _context;

    public AnalysisController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var actors = _context.Actors.ToList();
        var movies = _context.Movies.ToList();
        var roles = _context.Roles.ToList();

        var service = new MovieAnalysisService();
        var result = service.FindTopCoStars(actors, movies, roles);

        return Ok(new
        {
            Actor1Id = result.Actor1Id,
            Actor2Id = result.Actor2Id,
            Movies = result.Item3
        });
    }
}