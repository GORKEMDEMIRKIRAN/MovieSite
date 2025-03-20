



using System.ComponentModel.DataAnnotations;

namespace Entities.RepositoryModels
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}
        [Required]
        public String? CategoryType {get;set;} // film veya dizi
    }
}