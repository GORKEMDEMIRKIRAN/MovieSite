

//================================
using System.Threading.Tasks;
using System.Collections.Generic;
//================================
using Entities.TmdbModels;
//================================

namespace Repositories.TmdbApi.Abstract
{
    public interface ITmdbService
    {
        //========================================================
        // PAGE MOVIES AND SERIES
        Task<T?> GetAsync<T>(string requestUri,int page_number,int id,int value);
        Task<MovieApiPopularResult> GetPopularMoviesAsync(int page);
        Task<TvApiPopularResult> GetPopularTvAsync(int page);
        Task<MovieApiTopRatedResult> GetTopRatedMoviesAsync(int page);
        Task<TvApiTopRatedResult> GetTopRatedTvAsync(int page);
        //========================================================
        // DETAILS
        Task<MovieDetails> GetMovieDetailsAsync(int id);
        Task<SeriesDetails> GetTvDetailsAsync(int id);
        //========================================================
        // VIDEO DETAILS
        Task<VideoResultsList> GetMovieVideoDetailsAsync(int id);
        Task<VideoResultsList> GetSerieVideoDetailsAsync(int id);
        // //========================================================
        // // SIMILAR DETAILS
        Task<MovieApiSimilarResult> GetMovieSimilarDetailsAsync(int id);
        Task<TvApiSimilarResult> GetSerieSimilarDetailsAsync(int id);
        //========================================================
        // TV AND MOVIE TYPE LIST
        Task<TypeResultList> GetMovieTypeList();
        Task<TypeResultList> GetSerieTypeList();
        //========================================================
        // TV AND MOVIDE TYPE DETAILS
        Task<MovieApiPopularResult> GetTypeMovies(int id,int page);
        Task<TvApiPopularResult> GetTypeSeries(int id,int page);
        //========================================================
        Task<GeneralMovieResult> GetMovieDayTrendAsync(int page);
        Task<GeneralMovieResult> GetMovieWeekTrendAsync(int page);
        Task<GeneralTvResult> GetTvDayTrendAsync(int page);
        Task<GeneralTvResult> GetTvWeekTrendAsync(int page);
        Task<GeneralTvResult> GetTvUpcomingAsync(int page);
        Task<GeneralTvResult> GetTvNowPlayingAsync(int page);
        Task<GeneralMovieDatesResult> GetMovieNowPlayingAsync(int page);
        Task<GeneralMovieDatesResult> GetMovieUpComingAsync(int page);
        Task<moviecredits> GetMovieCreditsAsync(int id);
        Task<tvcredits> GetTvCreditsAsync(int id);
        //========================================================
       
    }

}