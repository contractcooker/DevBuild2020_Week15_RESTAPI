using IceCreamApi.Models;
using System.Collections.Generic;

namespace IceCreamAPI.Services
{
    public interface IDAL
    {
        int CreateMovie(Movie m);
        int DeleteMovieById(int id);
        Movie GetMovieById(int id);
        string[] GetMovieCategories();
        IEnumerable<Movie> GetMoviesAll();
        IEnumerable<Movie> GetMoviesByCategory(string category);
        Movie GetMovieByRow(int random);
        Movie GetMovieByCategoryByRow(int random);
        //int UpdateProductById(Product prod);
    }
}