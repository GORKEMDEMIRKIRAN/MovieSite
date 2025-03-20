
//=========================================
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Net.Http.Json;
//=========================================
using Entities.TmdbModels;
using Repositories.TmdbApi.Abstract;
//=========================================

namespace Repositories.TmdbApi.Concrete
{
    public class TmdbRepository:ITmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TmdbRepository(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient=httpClient;
            //appsettings.json içideki api anahtarını okumak için configuration tanımladık.
            _configuration=configuration;
            // tmdb api için ziyaret edeceğimiz url yolunu httpClient tanımladık.
            _httpClient.BaseAddress=new Uri("https://api.themoviedb.org/3/");

        }

        // BU METOT İLE VERİLEN LİSTEYİ SAYFA NUMARASINA GÖRE VERİCEKTİR.
        //===========================================================================================================================
        // POSTMAN SORGUSU
        // "https://api.themoviedb.org/3/movie/popular?api_key={{ApiKey}}&page=500"
        // Bu yapıya göre getAsync kurdum.
    
        public async Task<T?> GetAsync<T>(string requestUri,int page_number,int id,int value) // GetAsync metodunu ekledik
        {
            /* value ile yapmak istediğimiz sorguları yapacağız.*/
            //====================================================
            //value==1 ise dizi ve film detay sorgusunu getirir.
            //value==2 ise dizi ve film video detaları gelicektir.
            // diğer durumlarda sayfaya göre film ve diziler gelicektir.
            //====================================================
            var apiKey = _configuration["TMDB:ApiKey"];
            if(value == 1)
            { 
                // bu kısım bize film veya dizi detayını döndürecektir.
                // https://api.themoviedb.org/3/movie/1978?api_key={{ApiKey}}
                
                var fullRequestUri=$"{requestUri}/{id}?api_key={apiKey}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);

            }else if(value==2){
                // video sorgusu
                var fullRequestUri=$"{requestUri}/{id}/videos?api_key={apiKey}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
            }else if(value==3){
                var fullRequestUri=$"{requestUri}/{id}/similar?api_key={apiKey}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
            }else if(value==4){
                // eğer value == 4 ise bizi tv veya movie alanı altındaki tür listesini vericektir.
                var fullRequestUri=$"{requestUri}?api_key={apiKey}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
            }else if(value==5){
                // bu kısım tıklanan film türündeki tür id gelecek ve sayfa numarası 1 ile başlatıcak.
                var fullRequestUri=$"{requestUri}?api_key={apiKey}&with_genres={id}&page={page_number}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
                
            }else if(value==6){
                // tv-movie oyuncu kadrosu
                // 1- moviecredits
                // 2- tvcredits
                var fullRequestUri=$"{requestUri}/{id}/credits?api_key={apiKey}";
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
            }
            else{
                // film veya dizi serisini vercektir.
                // https://api.themoviedb.org/3/movie/popular?api_key={{ApiKey}}
                // VERİLECEKLER
                // 1-moviedaytrend
                // 2-movieweektrend
                // 3-tvdaytrend
                // 4-tvweektrend
                // 5-movieupcoming
                // 6-tvupcoming
                // 7-movienowplaying
                // 8-tvnowplaying
                var fullRequestUri = $"{requestUri}?api_key={apiKey}&page={page_number}"; // API anahtarını sorgu parametresi olarak ekle
                return await _httpClient.GetFromJsonAsync<T>(fullRequestUri);
            }
        }
        //=========================================================================================================================
        // ortak model
        public async Task<GeneralMovieResult> GetMovieDayTrendAsync(int page=1)
        {
            return await GetAsync<GeneralMovieResult>($"trending/movie/day",page,0,0);
        }
        public async Task<GeneralMovieResult> GetMovieWeekTrendAsync(int page=1)
        {
            return await GetAsync<GeneralMovieResult>($"trending/movie/week",page,0,0);
        }
        public async Task<GeneralTvResult> GetTvDayTrendAsync(int page=1)
        {
            return await GetAsync<GeneralTvResult>($"trending/tv/day",page,0,0);
        }
        public async Task<GeneralTvResult> GetTvWeekTrendAsync(int page=1)
        {
            return await GetAsync<GeneralTvResult>($"trending/tv/week",page,0,0);
        }
        public async Task<GeneralTvResult> GetTvUpcomingAsync(int page=1)
        {
            return await GetAsync<GeneralTvResult>($"tv/on_the_air",page,0,0);
        }
        public async Task<GeneralTvResult> GetTvNowPlayingAsync(int page=1)
        {
            return await GetAsync<GeneralTvResult>($"tv/airing_today",page,0,0);
        }
        //===========================================================
        // bu sonuçlarda tarihte var farklı model tanımlanıcaktır.
        public async Task<GeneralMovieDatesResult> GetMovieNowPlayingAsync(int page=1)
        {
            return await GetAsync<GeneralMovieDatesResult>($"movie/now_playing",page,0,0);
        }
        public async Task<GeneralMovieDatesResult> GetMovieUpComingAsync(int page=1)
        {
            return await GetAsync<GeneralMovieDatesResult>($"movie/upcoming",page,0,0);
        }
        //===========================================================
        // credits oyuncu kadroları
        // id-cast çıktısı
        public async Task<moviecredits> GetMovieCreditsAsync(int id)
        {
            return await GetAsync<moviecredits>($"movie",0,id,6);
        }
        // cast çıktısı
        public async Task<tvcredits> GetTvCreditsAsync(int id)
        {
            return await GetAsync<tvcredits>($"tv",0,id,6);
        }


        //=========================================================================================================================
        // TV VE MOVIE DETAYLARINI ALACAK METOTLAR
        public async Task<MovieDetails> GetMovieDetailsAsync(int id)
        {
            return await GetAsync<MovieDetails>($"movie",0,id,1);
        }
        public async Task<SeriesDetails> GetTvDetailsAsync(int id)
        {
            return await GetAsync<SeriesDetails>($"tv",0,id,1);
        }
        //==========================================================================
        // populer filmleri alacak metot
        public async Task<MovieApiPopularResult> GetPopularMoviesAsync(int page=1)
        {
            return await GetAsync<MovieApiPopularResult>($"movie/popular",page,0,0);
        }
        // popüler tv alacak metot
        public async Task<TvApiPopularResult> GetPopularTvAsync(int page=1)
        {
            return await GetAsync<TvApiPopularResult>($"tv/popular",page,0,0);
        }
        //==========================================================================
        // en yüksek oy alan filmleri getirecek metot
        public async Task<MovieApiTopRatedResult> GetTopRatedMoviesAsync(int page=1)
        {
            return await GetAsync<MovieApiTopRatedResult>($"movie/top_rated",page,0,0);
        }
        // en yüksek oy lana dizileri getirecek metot
        public async Task<TvApiTopRatedResult> GetTopRatedTvAsync(int page=1)
        {
            return await GetAsync<TvApiTopRatedResult>($"tv/top_rated",page,0,0);
        }



        //==========================================================================
        // TV VE MOVİE DETAYLARINI ALACAK METOTLAR
        public async Task<VideoResultsList> GetMovieVideoDetailsAsync(int id)
        {
            return await GetAsync<VideoResultsList>($"movie",0,id,2);
        }
        public async Task<VideoResultsList> GetSerieVideoDetailsAsync(int id)
        {
            return await GetAsync<VideoResultsList>($"tv",0,id,2);
        }
        //==========================================================================
        // BENZER FİLMLERİ VE DİZİLERİ ALACAK METOTLAR
        // benzer film çıktıları popular dizi ve tv ile aynı cevap mdoeline
        // sahip olduğu için bizde tv ve film için olan modelleri ekliyoruz.
        public async Task<MovieApiSimilarResult> GetMovieSimilarDetailsAsync(int id)
        {
            return await GetAsync<MovieApiSimilarResult>($"movie",0,id,3);
        }
        public async Task<TvApiSimilarResult> GetSerieSimilarDetailsAsync(int id)
        {
            return await GetAsync<TvApiSimilarResult>($"tv",0,id,3);
        }        
        //==========================================================================
        // TV VE MOVİE TÜRLERİNİ ÇEKECEĞİM.
        public async Task<TypeResultList> GetMovieTypeList()
        {  
            return await GetAsync<TypeResultList>($"genre/movie/list",0,0,4);
        }
        public async Task<TypeResultList> GetSerieTypeList()
        {  
            return await GetAsync<TypeResultList>($"genre/tv/list",0,0,4);
        }
        //==========================================================================
        // tv ve movie türleri id göre liste getirme
        // popular tv ve movie metotları javascript içerikleri aynı olduğu tanımladığım
        // popüler modelleri kullanacağım.
        // id= movie veya tv id temsil ediyor page sayfa numarası
        public async Task<MovieApiPopularResult> GetTypeMovies(int id,int page=1)
        {  
            return await GetAsync<MovieApiPopularResult>($"discover/movie",page,id,5);
        }
        public async Task<TvApiPopularResult> GetTypeSeries(int id,int page=1)
        {  
            return await GetAsync<TvApiPopularResult>($"discover/tv",page,id,5);
        }
        //==========================================================================

        
    }
}

