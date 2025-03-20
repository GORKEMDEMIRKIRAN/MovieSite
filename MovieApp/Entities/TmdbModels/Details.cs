

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.TmdbModels
{
    //======================================================================
    // FILM DETAYLARINI ALDIĞIM BİR MODEL VE MODEL İÇİNDE
    // BAZI LİSTELER VAR BUNLARIDA ALTTA TANIMLADIM.
    //=============================================
    public class MovieDetails
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonPropertyName("belongs_to_collection")]
        public object? BelongsToCollection { get; set; }

        [JsonPropertyName("budget")]
        public int? Budget { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre>? Genres { get; set; }

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonPropertyName("origin_country")]
        public List<string>? OriginCountry { get; set; }

        [JsonPropertyName("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompany>? ProductionCompanies { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry>? ProductionCountries { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("revenue")]
        public int? Revenue { get; set; }

        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<SpokenLanguage>? SpokenLanguages { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("tagline")]
        public string? Tagline { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("video")]
        public bool? Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int? VoteCount { get; set; }
    }
    //=============================================
        // TV DETAYLARINI ALDIĞIM BİR MODEL VE MODEL İÇİNDE
    // BAZI LİSTELER VAR BUNLARIDA ALTTA TANIMLADIM.
    //=============================================
    public class SeriesDetails
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("created_by")]
        public List<Creator> CreatedBy { get; set; }

        [JsonPropertyName("episode_run_time")]
        public List<int> EpisodeRunTime { get; set; }

        [JsonPropertyName("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("in_production")]
        public bool InProduction { get; set; }

        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; }

        [JsonPropertyName("last_air_date")]
        public string LastAirDate { get; set; }

        [JsonPropertyName("last_episode_to_air")]
        public Episode LastEpisodeToAir { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("next_episode_to_air")]
        public object NextEpisodeToAir { get; set; }

        [JsonPropertyName("networks")]
        public List<Network> Networks { get; set; }

        [JsonPropertyName("number_of_episodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonPropertyName("number_of_seasons")]
        public int NumberOfSeasons { get; set; }

        [JsonPropertyName("origin_country")]
        public List<string> OriginCountry { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("original_name")]
        public string OriginalName { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonPropertyName("seasons")]
        public List<Season> Seasons { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
    //======================================================================

    // FİLM VE DİZİLER İÇİN ORTAK VE ORTAK OLMAYAN MODEL TANIMLARI
    // ÜST KISIMLARIN İÇİNDEKİ LİSTELERİ TEMSİL EDİYORLAR
    //======================================================================
    public class Episode
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }

        [JsonPropertyName("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonPropertyName("episode_type")]
        public string EpisodeType { get; set; }

        [JsonPropertyName("production_code")]
        public string ProductionCode { get; set; }

        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("show_id")]
        public int ShowId { get; set; }

        [JsonPropertyName("still_path")]
        public string StillPath { get; set; }
    }
    public class Creator
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("credit_id")]
        public string CreditId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("original_name")]
        public string OriginalName { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePath { get; set; }
    }

    public class Season
    {
        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }

        [JsonPropertyName("episode_count")]
        public int EpisodeCount { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }
    }
    public class Network
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }
    }
    //=============================================
    // ORTAK KISIMLARI
    public class Genre
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
    }
    //=============================================
    public class ProductionCompany
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }
    }
    //=============================================
    public class ProductionCountry
    {
        [JsonPropertyName("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    //=============================================
    public class SpokenLanguage
    {
        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    //=============================================
    //======================================================================
    // Şimdi video ve image sonuçlarını döndürecek modelleri tanımlama
    // tv ve serieste aynı modeller olduğu için ortak kullanılacaktır.
    // details kısmı buraya

    // burada daha sonra images bölümüne bakabiliriz ama şaun gerek yok
    public class VideoDetails
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string? Iso639_1 { get; set; }

        [JsonPropertyName("iso_3166_1")]
        public string? Iso3166_1 { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("site")]
        public string? Site { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("official")]
        public bool? Official { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime? PublishedAt { get; set; }
    }



    //======================================================================
    // benzer filmler için elimizde hazır modeler var onları kullanırız.
    //======================================================================
} 