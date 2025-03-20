




//====================================
// microsoft içindeki mevcut paketler
using Microsoft.AspNetCore.Mvc;
//====================================
// etkinleştirdiğimiz yollar
using Repositories.ServerRepository.Abstract;
using Repositories.ServerRepository.Concrete.EfCore;
using Entities.RepositoryModels;
//====================================


namespace movieapp.Controllers
{

    public class HomeController:Controller
    {
        private IMovieRepository _movieRepository;
        public HomeController(IMovieRepository movieRepository)
        {
            this._movieRepository=movieRepository;
        }
        public IActionResult Index()
        {
            // index.cshhtml içine filmleri lsite olarak gönderdik.
            var movies=_movieRepository.GetAllMovies();
            return View(movies);
        }
    }
}