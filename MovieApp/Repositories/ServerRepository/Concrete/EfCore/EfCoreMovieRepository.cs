

//====================================
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//====================================
using Repositories.ServerRepository.Abstract;
using Entities.RepositoryModels;
//====================================



namespace Repositories.ServerRepository.Concrete.EfCore
{
    public class EfCoreMovieRepository:IMovieRepository
    {  
        //database bütün movie(filmleri) lsite olarak alıyoruz.
        public List<Movie> GetAllMovies()
        {
            using(var context=new ShopContext())
            {
                var movies=context.Movies.ToList();
                return movies;
            };
        }
        public List<Movie> GetAllYearMovies(int year)
        {
            using(var context=new ShopContext())
            {
                var yearMovies=context
                    .Movies
                    .Where(i=>i.Year==year).ToList();
                return yearMovies;
            };
        }

        // verilen id=1 ise filmler 
        // verilen id=2 ise dizi olanları getirecektir.

        // movies içinde "where" ile sorgu açar ve  MovieCategories 
        // her birinden movie içindeki id ve moviecategories içindeki
        // id eşit olan ve moviecategories içindeki categoryıd=1,2 olanları
        // getireceğiz.
        public List<Movie> GetAllFilmMovies(int id)
        {
            using(var context = new ShopContext())
            {
                var films=context
                    .Movies
                    .Where(m=>context.MovieCategories
                    .Any(mc=>mc. MovieId == m.MovieId && mc.CategoryId==id)).ToList();  
                
                return films;
            };
      
        }
        // public List<Movie> GetAllMovieTypeList(string name)
        // {
        //     using(var context=new ShopContext())
        //     {
        //         var selectType=context
        //             .Movies
        //             .Where(m=>context.MovieCategories
        //             .Any(mc=>mc.MovieId==m.MovieId && mc.TypeId==)).ToList();

        //         return selectType;
        //     };
        // }
    }
}