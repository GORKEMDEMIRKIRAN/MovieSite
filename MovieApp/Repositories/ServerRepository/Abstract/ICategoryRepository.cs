


using Entities.RepositoryModels;

namespace Repositories.ServerRepository.Abstract
{
    public interface ICategoryRepository
    {
        List<MovieType> GetAllCategories();
    }
}