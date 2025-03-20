

using System.ComponentModel.DataAnnotations;




namespace Entities.RepositoryModels
{
    public class Movie
    {
        [Key]
        public int MovieId {get;set;}
        [Required]
        public String? MovieName {get;set;}
        [Required]
        public decimal Year {get;set;}
        public float Imdb {get;set;}
        [Required]
        public String? Languages{get;set;}
        [Required]
        public String? Image {get;set;}
        public String? Country {get;set;}
    }
}