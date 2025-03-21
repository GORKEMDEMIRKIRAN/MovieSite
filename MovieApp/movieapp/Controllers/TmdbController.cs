




//=======================================
using Newtonsoft.Json;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;        
//=======================================
using Repositories.TmdbApi.Abstract;        // Tmdb repository interface
using Repositories.TmdbApi.Concrete;        // Tmdb repository
using Entities.TmdbModels;                  // Entities model way
//=======================================



namespace movieapp.Controllers
{

    public class TmdbController:Controller
    {
        // Dependency Injection
        private readonly ITmdbService _tmdbService;
        public TmdbController(ITmdbService tmdbService)
        {
            _tmdbService=tmdbService;
        }
        //===================================================================================================
        // TV AND MOVIE POPULAR LIST
        public async Task<IActionResult> MoviePopular(int page=1)
        {
            // postmande inceledim maximum 500 sayfa var.
            //var movies= await _tmdbService.GetPopularMoviesAsync(value);
            var movies= await _tmdbService.GetPopularMoviesAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                // bu kısımda dışarıda yazdığım static metot ile poster ve arka plan
                // görsellerinin yolunu güncelledik.
                // örnek yol:"https://image.tmdb.org/t/p/w400/BackdropPath" olarak güncelleniyor.
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    MoviePopular=movies.Results,
                    TotalPages=500,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return View();
            }
        }

        public async Task<IActionResult> SeriesPopular(int page=1)
        {
            var movies=await _tmdbService.GetPopularTvAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                // bu döngü seçili sayfadaki 20 tane video bilgisini modele aktarıf sayfaya göndermektedir.
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                // Buradaki model ile results üzerinde değişiklik yaparak metottan gelen bütün
                // sonuçlar için model oluşturdum ve atadım.
                var answer = new ResultPage{
                    Page=movies.Page,
                    TvPopular=movies.Results,
                    TotalPages=500,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return View();
            }
        }
        //===================================================================================================
        // TV AND MOVIE TOP RATED LIST
        public async Task<IActionResult> MovieTopRated(int page=1)
        {
            
            // postmande inceledim maximum 500 sayfa var.
            //var movies= await _tmdbService.GetPopularMoviesAsync(value);
            var movies= await _tmdbService.GetTopRatedMoviesAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                // bu kısımda dışarıda yazdığım static metot ile poster ve arka plan
                // görsellerinin yolunu güncelledik.
                // örnek yol:"https://image.tmdb.org/t/p/w400/BackdropPath" olarak güncelleniyor.
                
                //---------------------------------------------------------------------
                // ÖN İŞLEM KISMI
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                //---------------------------------------------------------------------
                // SAYFAYA GÖNDERİLECEK MDOEL
                var answer = new ResultPage{
                    Page=movies.Page,
                    MovieTopRated=movies.Results,
                    TotalPages=500,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
                //---------------------------------------------------------------------
            }else{
                return View();
            }
        }

        public async Task<IActionResult> SeriesTopRated(int page=1)
        {
            // postmande inceledim maximum 500 sayfa var.
            //var movies= await _tmdbService.GetPopularMoviesAsync(value);
            var movies= await _tmdbService.GetTopRatedTvAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                // bu kısımda dışarıda yazdığım static metot ile poster ve arka plan
                // görsellerinin yolunu güncelledik.
                // örnek yol:"https://image.tmdb.org/t/p/w400/BackdropPath" olarak güncelleniyor.
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    TvTopRated=movies.Results,
                    TotalPages=109,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return View();
            }

    }
        //===================================================================================================
        // TV AND MOVIE DETAIL PAGES
        public async Task<IActionResult> MovieDetails(int id)
        {

            var Detailresults=await _tmdbService.GetMovieDetailsAsync(id);
            var VideoResults=await  _tmdbService.GetMovieVideoDetailsAsync(id);
            var SimilarResults=await _tmdbService.GetMovieSimilarDetailsAsync(id);
            var Members=await _tmdbService.GetMovieCreditsAsync(id);
            if(Detailresults != null)
            {
                // bu kısımda psoter resmi parçasına yolu entegre edicektir.
                Detailresults.PosterPath=GenerateImageUrl(Detailresults.PosterPath);
                Detailresults.BackdropPath=GenerateImageUrl(Detailresults.BackdropPath);
                foreach(var result in SimilarResults.Results)
                {
                    if(result != null)
                    {
                        result.PosterPath=GenerateImageUrl(result.PosterPath);
                        result.BackdropPath=GenerateImageUrl(result.BackdropPath);
                    }

                }
                var answers=new ResultPage{
                    MovieDetails=Detailresults,
                    MovieVideo=VideoResults,
                    moviecredits=Members,
                    MovieSimilar=new MovieSimilar{
                        Page=SimilarResults.Page,
                        TotalPages=SimilarResults.TotalPages,
                        TotalResults=SimilarResults.TotalResults,
                        MSimilar=SimilarResults.Results
                    }
                };
                return View(answers);
            }
            return NotFound();
        }
        public async Task<IActionResult> SeriesDetails(int id)
        {
            var SerieDetails=await _tmdbService.GetTvDetailsAsync(id);

            var VideoResults=await  _tmdbService.GetSerieVideoDetailsAsync(id);
            var SimilarResults=await _tmdbService.GetSerieSimilarDetailsAsync(id);
            var Members=await _tmdbService.GetTvCreditsAsync(id);
            if(SerieDetails != null)
            {
                // bu kısımda psoter resmi parçasına yolu entegre edicektir.
                SerieDetails.PosterPath=GenerateImageUrl(SerieDetails.PosterPath);
                SerieDetails.BackdropPath=GenerateImageUrl(SerieDetails.BackdropPath);
                foreach(var result in SimilarResults.Results)
                {
                    if(result != null)
                    {
                        result.PosterPath=GenerateImageUrl(result.PosterPath);
                        result.BackdropPath=GenerateImageUrl(result.BackdropPath);
                    }
                }
                var answers=new ResultPage{
                    TvDetails=SerieDetails,
                    SeriesVideo=VideoResults,
                    tvcredits=Members,
                    SerieSimilar=new SerieSimilar{
                        Page=SimilarResults.Page,
                        TotalPages=SimilarResults.TotalPages,
                        TotalResults=SimilarResults.TotalResults,
                        SSimilar=SimilarResults.Results
                    }
                };
                return View(answers);
            }
            return NotFound();
        }
        //===================================================================================================
        // TV AND MOVIE TYPE LIST
        // id bilgisi genre_id temsil ediyor(movie türünün id)
        public async Task<IActionResult> MovieTypePage(int id ,int page=1,string name="")
        {
            var data= await _tmdbService.GetTypeMovies(id,page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(data.Results != null)
            {
                foreach(var item in data.Results)
                {
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                }
                var answer = new ResultPage{
                    Id=id,
                    Page=data.Page,
                    MoviePopular=data.Results,
                    TotalPages=499,
                    TotalResults=data.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    },
                    Name=name,
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }
        // id bilgisi genre_id temsil ediyor(tv türünün id)
        public async Task<IActionResult> SerieTypePage(int id,int page=1,string name="")
        {
            // verilen film tür id ve sayfa bilgisi ile listeleyecektir.
            var data= await _tmdbService.GetTypeSeries(id,page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(data.Results != null)
            {
                foreach(var item in data.Results)
                {
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                }
                var answer = new ResultPage{
                    Id=id,
                    Page=data.Page,
                    TvPopular=data.Results,
                    TotalPages=499,
                    TotalResults=data.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    },
                    Name=name,
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }
        //===================================================================================================
        // TV AND MOVIE DAILY TREND LIST
        public async Task<IActionResult> MovieDayTrend(int page=1)
        {
            var movies=await _tmdbService.GetMovieDayTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralMovieModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }
        

        public async Task<IActionResult> MovieWeekTrend(int page=1)
        {
            var movies=await _tmdbService.GetMovieWeekTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralMovieModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }      


        public async Task<IActionResult> TvDayTrend(int page=1)
        {
            var movies=await _tmdbService.GetTvDayTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralTvModel=movies.Results,
                    TotalPages=500,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }       

        
        public async Task<IActionResult> TvWeekTrend(int page=1)
        {
            var movies=await _tmdbService.GetTvWeekTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralTvModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }        
        
        // TV,MOVIE UP COMING AND NOW PLAYING LIST
        public async Task<IActionResult> TvUpComing(int page=1)
        {
            var movies=await _tmdbService.GetTvUpcomingAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralTvModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }        
        
        
        public async Task<IActionResult> TvNowPlaying(int page=1)
        {
            var movies=await _tmdbService.GetTvNowPlayingAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralTvModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }        
        
        
        
        public async Task<IActionResult> MovieUpComing(int page=1)
        {
            var movies=await _tmdbService.GetMovieDayTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralMovieModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }        
        
        
        public async Task<IActionResult> MovieNowPlaying(int page=1)
        {
            var movies=await _tmdbService.GetMovieDayTrendAsync(page);
            var movieTypes= await _tmdbService.GetMovieTypeList();
            var serieTypes= await _tmdbService.GetSerieTypeList();
            if(movies.Results !=null)
            {
                foreach(var item in movies.Results)
                {
                    item.BackdropPath=GenerateImageUrl(item.BackdropPath);
                    item.PosterPath=GenerateImageUrl(item.PosterPath);
                }
                var answer = new ResultPage{
                    Page=movies.Page,
                    GeneralMovieModel=movies.Results,
                    TotalPages=movies.TotalPages,
                    TotalResults=movies.TotalResults,
                    alltypelist=new AllTypeList{
                        Movie=movieTypes,
                        Tv=serieTypes
                    }
                };
                return View(answer);
            }else{
                return NotFound();
            }
        }    

        //===================================================================================================
        // The method that updates the poster and background image path
        public static string GenerateImageUrl(string image)
        {
            string baseUrl = "https://image.tmdb.org/t/p/";
            string imageSize = "w400";
            if(image is null){
                return null;
            }
            return baseUrl + imageSize + image;
        }
        //===================================================================================================

    }
}
