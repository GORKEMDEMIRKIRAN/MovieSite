
//====================================
using System.Collections.Generic;
//====================================
using Repositories.ServerRepository.Abstract;   
using Entities.RepositoryModels;
//====================================



namespace Repositories.ServerRepository.Concrete.EfCore
{
    public class EfCoreCategoryRepository:ICategoryRepository
    {
        public List<MovieType> GetAllCategories()
        {
            using(var context = new ShopContext())
            {
                var types=context.MovieTypes.ToList();

                return types;
            }
        }
    }
}