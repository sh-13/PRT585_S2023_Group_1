using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_B.DBContext;
using Task_B.Models;

namespace Task_B.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesDBContext _movieDbContext;

        public HomeController(ILogger<HomeController> logger, MoviesDBContext movieDbContext)
        {
            _logger = logger;
            _movieDbContext = movieDbContext;
        }

        public IActionResult Index()
        {
            MovieModel movieModel = new MovieModel();
            movieModel.MovieList = new List<Movie>();
            var data = _movieDbContext.Movies.ToList();
            foreach (var movie in data)
            {
                movieModel.MovieList.Add(new Movie
                {
                    Id = movie.Id,
                    Name = movie.MovieName,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    EmailAddress = movie.EmailAddress,
                    Category = movie.Category,
                    Language = movie.Language
                });
            }
            return View(movieModel);
        }

        // GET : Home/Create
        [HttpGet]
        public IActionResult Create()
        {
            Movie movie = new Movie();
            return View();
        }

        // POST : Home/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var movieData = new Movies()
            {
                MovieName = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                EmailAddress = movie.EmailAddress,
                Category = movie.Category,
                Language = movie.Language
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}