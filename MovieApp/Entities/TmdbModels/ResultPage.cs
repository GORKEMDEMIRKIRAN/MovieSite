



using System.Collections.Generic;
using System.Security.Principal;


namespace Entities.TmdbModels
{
    public class ResultPage
    {
        //=======================
        // tv ve movie aktarım türkeri için gerekli
        public int Id {get;set;}
        public string Name {get;set;}
        //=======================
        public int Page { get; set; }
        public int TotalPages {get;set;}
        public int TotalResults {get;set;}
        //=======================
        // Bu kısma sonucu aynı dönenleri alalım.
        public List<MoviePopularModel>? MoviePopular{ get; set; }
        public List<TvPopularModel>? TvPopular { get; set; }
        public List<MovieTopRatedModel>? MovieTopRated { get; set; }
        public List<TvTopRatedModel>? TvTopRated { get; set; }
        //======================
        // Details
        public MovieDetails? MovieDetails { get; set; }
        public SeriesDetails? TvDetails { get; set; }
        //=======================
        // Video
        public VideoResultsList? MovieVideo {get;set;}
        public VideoResultsList? SeriesVideo {get;set;}
        //=======================
        // Similar
        public MovieSimilar MovieSimilar {get;set;}
        public SerieSimilar SerieSimilar {get;set;}
        //=======================
        // movie and tv types 
        public AllTypeList alltypelist {get;set;}
        //=======================
        // tv ve movie oyuncu kadrosu
        public moviecredits moviecredits {get;set;}
        public tvcredits tvcredits {get;set;}
        // genel tv ve movie modeli buraya tanımladım.
        public List<GeneralMovieModel>? GeneralMovieModel {get;set;}
        public List<GeneralTvModel>? GeneralTvModel{get;set;}


    } 


}