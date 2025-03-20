

using System.Buffers.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.TmdbModels
{
    // bu kısımda movie/popular sorgusundan gelen
    // json çıktılarını alıyoruz.
    //=================================================
    public class MovieApiPopularResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        // popular içinde alacağımın json formatındaki
        // verilere eşit olan modeli tanımladık.
        public List<MoviePopularModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public class TvApiPopularResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TvPopularModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
    //===============================================
    public class MovieApiTopRatedResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<MovieTopRatedModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public class TvApiTopRatedResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TvTopRatedModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
    public class MovieApiSimilarResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<MovieSimilarModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
    public class TvApiSimilarResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TvSimilarModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    //===============================================
    // ortak tv ve film model listesi
    public class VideoResultsList
    {
        [JsonPropertyName("id")]
        public int id {get;set;}
        [JsonPropertyName("results")]
        public List<VideoDetails>? videoResults {get;set;}
    }

    //===============================================
    // tv ve movie türlerinin rotak bölümleri
    public class TypeResultList
    {
        // hata sorunları için boş liste başlatılır
        [JsonPropertyName("genres")]
        public List<TypeGenre> GenresList {get;set;} = new List<TypeGenre>();
    }


    public class TypeGenre
    {
        [JsonPropertyName("id")]
        public int Id {get;set;}
        [JsonPropertyName("name")]
        public string? TypeName {get;set;} = string.Empty;
    }
    //===============================================

    // ortak çıktısı olan apiler için 
    public class GeneralMovieResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        // popular içinde alacağımın json formatındaki
        // verilere eşit olan modeli tanımladık.
        public List<GeneralMovieModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
    
    public class GeneralTvResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        // popular içinde alacağımın json formatındaki
        // verilere eşit olan modeli tanımladık.
        public List<GeneralTvModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
    // ortak çıktısı olan apiler için ama dates değeride var

    public class GeneralMovieDatesResult
    {
        [JsonPropertyName("dates")]
        public List<Dates>? Dates {get;set;}
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        // popular içinde alacağımın json formatındaki
        // verilere eşit olan modeli tanımladık.
        public List<GeneralMovieModel>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public class Dates
    {
        [JsonPropertyName("maximum")]
        public DateTime maximum {get;set;}
        [JsonPropertyName("minimum")]
        public DateTime minimum {get;set;}
    }
    //===============================================

    public class moviecredits
    {
        [JsonPropertyName("id")]
        public int Id {get;set;}
        [JsonPropertyName("cast")]
        public List<Member>? castList {get;set;}
    }
    
    public class tvcredits
    {
        [JsonPropertyName("cast")]
        public List<Member>? castList {get;set;}
    }
  

    // tv ve movie türlerinin aktarımı için model
    public class AllTypeList
    {
        public TypeResultList? Movie {get;set;}
        public TypeResultList? Tv {get;set;}
    }
    // benzer film aktarımları için model
    public class MovieSimilar{
        public int Page { get; set; }
        public int TotalPages {get;set;}
        public int TotalResults {get;set;}
        public List<MovieSimilarModel>?  MSimilar {get;set;}
    }

    public class SerieSimilar{
        public int Page { get; set; }
        public int TotalPages {get;set;}
        public int TotalResults {get;set;}
        public List<TvSimilarModel>?  SSimilar {get;set;}
    }


}