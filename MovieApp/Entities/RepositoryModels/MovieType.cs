
using System.ComponentModel.DataAnnotations;


namespace Entities.RepositoryModels
{
    public class MovieType
    {
        [Key]
        public int TypeId {get;set;}
        [Required]
        public String? TypeName {get;set;}  //gerilim,korku
    }
}