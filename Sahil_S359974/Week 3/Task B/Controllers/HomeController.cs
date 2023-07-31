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
            try
            {
                var movieData = new Movies()
                {
                    MovieName = movie.Name,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    EmailAddress = movie.EmailAddress,
                    Category = movie.Category,
                    Language = movie.Language
                };
                _movieDbContext.Movies.Add(movieData);
                _movieDbContext.SaveChanges();
                TempData["CreateStatus"] = 1;
            }
            catch (Exception _exception)
            {
                TempData["CreateStatus"] = 0;
            }
            return RedirectToAction("Index", "Home");
        }

        // GET : Home/Edit
        [HttpGet]
        public IActionResult Edit(int Id = 0)
        {
            Movie movie = new Movie();
            var data = _movieDbContext.Movies.Where(n => n.Id == Id).FirstOrDefault();
            if (data != null)
            {
                movie.Id = data.Id;
                movie.Name = data.MovieName;
                movie.ReleaseDate = data.ReleaseDate;
                movie.Director = data.Director;
                movie.EmailAddress = data.EmailAddress;
                movie.Category = data.Category;
                movie.Language = data.Language;
            }
            return View(movie);
        }

        // POST : Home/Edit
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            try
            {
                var data = _movieDbContext.Movies.Where(n => n.Id == movie.Id).FirstOrDefault();
                data.MovieName = movie.Name;
                data.ReleaseDate = movie.ReleaseDate;
                data.Director = movie.Director;
                data.EmailAddress = movie.EmailAddress;
                data.Category = movie.Category;
                data.Language = movie.Language;
                _movieDbContext.SaveChanges();
                TempData["UpdateStatus"] = 1;
            }
            catch (Exception _exception)
            {
                TempData["UpdateStatus"] = 0;
            }
            return RedirectToAction("Index", "Home");
        }

        // GET : Home/Delete
        [HttpGet]
        public IActionResult Delete(int Id = 0)
        {
            try
            {
                var data = _movieDbContext.Movies.Where(n => n.Id == Id).FirstOrDefault();
                if (data != null)
                {
                    _movieDbContext.Movies.Remove(data);
                    _movieDbContext.SaveChanges();
                    TempData["DeleteStatus"] = 1;
                }
            }
            catch (Exception _exception)
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "Home");
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