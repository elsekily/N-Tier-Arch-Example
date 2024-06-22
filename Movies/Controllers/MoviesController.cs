using Microsoft.AspNetCore.Mvc;
using Movies.Application.Services.Core;

namespace Movies.Controllers;
public class MoviesController : Controller
{
    private readonly IMoviesService moviesService;

    public MoviesController(IMoviesService moviesService)
    {
        this.moviesService = moviesService;
    }
    public async Task<IActionResult> Index([FromQuery] int page = 1, [FromQuery] string searchFilter = null)
    {
        return View(await moviesService.GetMoviesAsync(page, searchFilter));
    }
    
}
