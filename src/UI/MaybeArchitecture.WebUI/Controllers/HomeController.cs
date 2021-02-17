using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MaybeArchitecture.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var response = await _movieService.GetAsync();
            stopwatch.Stop();

            return View(new MovieListViewModel
            {
                Movies = response.Data,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds
            });
        }

        [HttpGet]
        public async Task<IActionResult> ImportMovie()
        {
            var response = await _movieService.ImportFromProvider();
            return Json(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}