


using System.ComponentModel.DataAnnotations;


namespace Entities.RepositoryModels
{
    public class MovieCategory
    {
        
        public int CategoryId {get;set;}
        public Category? category {get;set;}
        public int MovieId {get;set;}
        public Movie? movie {get;set;}
        public int TypeId {get;set;}
        public MovieType? movietype {get;set;}

    }
}