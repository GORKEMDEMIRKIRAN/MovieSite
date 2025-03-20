


//====================================
using Microsoft.EntityFrameworkCore;
//====================================
using Entities.RepositoryModels;
//====================================

namespace Repositories.ServerRepository.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {

            var context = new ShopContext();

            if (context.Categories.Count() == 0)
            {
                context.Categories.AddRange(Categories);
                context.SaveChanges(); // Kategorileri kaydet
            }

            if (context.MovieTypes.Count() == 0)
            {
                context.MovieTypes.AddRange(MovieTypes);
                context.SaveChanges(); // Film türlerini kaydet
            }

            if (context.Movies.Count() == 0)
            {
                context.Movies.AddRange(movies);
                context.SaveChanges(); // Filmleri kaydet
            }

            if (context.MovieCategories.Count() == 0)
            {
                context.MovieCategories.AddRange(moviecategories);
                context.SaveChanges(); // Film kategorilerini kaydet
            }
        }


        // category film veya dizi olabilir.
        private static Category[] Categories={
            new Category() {CategoryId=1,CategoryType="film"},
            new Category() {CategoryId=2,CategoryType="Series"}
        };
        // movietype film türünü temsil eder.
        private static MovieType[] MovieTypes={
            new MovieType() {TypeId=1,TypeName="Family"},
            new MovieType() {TypeId=2,TypeName="Action"},
            new MovieType() {TypeId=3,TypeName="Animation"},
            new MovieType() {TypeId=4,TypeName="Documentary"},
            new MovieType() {TypeId=5,TypeName="Science Fiction"},
            new MovieType() {TypeId=6,TypeName="Biography"},
            new MovieType() {TypeId=7,TypeName="Drama"},
            new MovieType() {TypeId=8,TypeName="Fantasy"},
            new MovieType() {TypeId=9,TypeName="Thriller"},
            new MovieType() {TypeId=10,TypeName="Mystery"},
            new MovieType() {TypeId=11,TypeName="Comedy"},
            new MovieType() {TypeId=12,TypeName="Horror"},
            new MovieType() {TypeId=13,TypeName="Adventure"},
            new MovieType() {TypeId=14,TypeName="Musical "},
            new MovieType() {TypeId=15,TypeName="Crime"},
            new MovieType() {TypeId=16,TypeName="Reality"},
            new MovieType() {TypeId=17,TypeName="Reality-TV"},
            new MovieType() {TypeId=18,TypeName="Romance"},
            new MovieType() {TypeId=19,TypeName="War"},
            new MovieType() {TypeId=20,TypeName="Sports"},
            new MovieType() {TypeId=21,TypeName="Crime"},
            new MovieType() {TypeId=22,TypeName="History"},
            new MovieType() {TypeId=23,TypeName="TV"},
            new MovieType() {TypeId=24,TypeName="Western"},
            new MovieType() {TypeId=25,TypeName="Short"}
        };

        private static Movie[] movies={
            new Movie(){MovieName="Avengers",Year=2012,Imdb=8.0f,Languages="English",Image="avengers1.jpg",Country="ABD"},
            new Movie(){MovieName="Avengers: Age of Ultron",Year=2015,Imdb=7.3f,Languages="English",Image="avengers2.jpg",Country="ABD"},
            new Movie(){MovieName="Avengers: Infinity War",Year=2018,Imdb=8.4f,Languages="English",Image="avengers3.webp",Country="ABD"},
            new Movie(){MovieName="Avengers: End Game",Year=2019,Imdb=8.4f,Languages="English",Image="avengers4.webp",Country="ABD"},
            new Movie(){MovieName="Captain America: The Winter Soldier",Year=2014,Imdb=7.8f,Languages="English",Image="captan2.jpg",Country="ABD"},
            new Movie(){MovieName="Captain America: Civil War",Year=2016,Imdb=7.8f,Languages="English",Image="captan3.webp",Country="ABD"},
            new Movie(){MovieName="Hulk-1",Year=2003,Imdb=6.6f,Languages="English",Image="hulk1.jpg",Country="ABD"},
            new Movie(){MovieName="Hulk-2",Year=2008,Imdb=5.6f,Languages="English",Image="hulk2.jpg",Country="ABD"},
            new Movie(){MovieName="Iron Man 1",Year=2008,Imdb=7.9f,Languages="English",Image="iron_man1.webp",Country="ABD"},
            new Movie(){MovieName="Iron Man 3",Year=2013,Imdb=7.1f,Languages="English",Image="iron_man3.webp",Country="ABD"},
            new Movie(){MovieName="Thor 1",Year=2011,Imdb=7.0f,Languages="English",Image="thor1.jpg",Country="ABD"},
            new Movie(){MovieName="Thor 2",Year=2013,Imdb=6.7f,Languages="English",Image="thor2.jpeg",Country="ABD"},
            new Movie(){MovieName="Thor 3",Year=2017,Imdb=7.9f,Languages="English",Image="thor3.jpg",Country="ABD"},
            new Movie(){MovieName="Thor 4",Year=2022,Imdb=6.2f,Languages="English",Image="thor4.jpeg",Country="ABD"}
        };

        private static MovieCategory[] moviecategories = {
            new MovieCategory() { CategoryId = 1, MovieId = 1, TypeId = 2 }, // Avengers, Action
            new MovieCategory() { CategoryId = 1, MovieId = 1, TypeId = 5 }, // Avengers, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 2, TypeId = 2 }, // Avengers: Age of Ultron, Action
            new MovieCategory() { CategoryId = 1, MovieId = 2, TypeId = 5 }, // Avengers: Age of Ultron, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 3, TypeId = 2 }, // Avengers: Infinity War, Action
            new MovieCategory() { CategoryId = 1, MovieId = 3, TypeId = 5 }, // Avengers: Infinity War, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 4, TypeId = 2 }, // Avengers: End Game, Action
            new MovieCategory() { CategoryId = 1, MovieId = 4, TypeId = 5 }, // Avengers: End Game, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 5, TypeId = 2 }, // Captain America: The Winter Soldier, Action
            new MovieCategory() { CategoryId = 1, MovieId = 5, TypeId = 5 }, // Captain America: The Winter Soldier, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 6, TypeId = 2 }, // Captain America: Civil War, Action
            new MovieCategory() { CategoryId = 1, MovieId = 6, TypeId = 5 }, // Captain America: Civil War, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 7, TypeId = 2 }, // Hulk-1, Action
            new MovieCategory() { CategoryId = 1, MovieId = 7, TypeId = 5 }, // Hulk-1, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 8, TypeId = 2 }, // Hulk-2, Action
            new MovieCategory() { CategoryId = 1, MovieId = 8, TypeId = 5 }, // Hulk-2, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 9, TypeId = 2 }, // Iron Man 1, Action
            new MovieCategory() { CategoryId = 1, MovieId = 9, TypeId = 5 }, // Iron Man 1, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 10, TypeId = 2 }, // Iron Man 3, Action
            new MovieCategory() { CategoryId = 1, MovieId = 10, TypeId = 5 }, // Iron Man 3, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 11, TypeId = 2 }, // Thor 1, Action
            new MovieCategory() { CategoryId = 1, MovieId = 11, TypeId = 5 }, // Thor 1, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 12, TypeId = 2 }, // Thor 2, Action
            new MovieCategory() { CategoryId = 1, MovieId = 12, TypeId = 5 }, // Thor 2, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 13, TypeId = 2 }, // Thor 3, Action
            new MovieCategory() { CategoryId = 1, MovieId = 13, TypeId = 5 }, // Thor 3, Science Fiction

            new MovieCategory() { CategoryId = 1, MovieId = 14, TypeId = 2 }, // Thor 4, Action
            new MovieCategory() { CategoryId = 1, MovieId = 14, TypeId = 5 } // Thor 4, Science Fiction
            };
    }
}