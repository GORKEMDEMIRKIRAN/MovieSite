



//=======================================
using System.Collections.Generic;
using System.Diagnostics.Contracts;
//=======================================
using Entities.RepositoryModels;


//=======================================



namespace Repositories.ServerRepository.Abstract
{
    public interface IMovieRepository
    {
        // bütün film bilgileri alma metot
        List<Movie> GetAllMovies();
        // sadece yıllara göre ürünleri alan liste
        List<Movie> GetAllYearMovies(int year);
        // film kategori türü
        List<Movie> GetAllFilmMovies(int id);

        //List<Movie> GetAllMovieTypeList(string name);
    }
}