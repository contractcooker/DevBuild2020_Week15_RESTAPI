using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamApi.Models;
using IceCreamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBuild2020_Week15_BuildRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IDAL dal;

        public MovieController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpDelete("{id}")]
        public Object Delete (int id)
        {
            int result = dal.DeleteMovieById(id);
            if (result > 0)
            {
                return new { succeess = true };
            }
            else
            {
                return new { success = false };
            }
        }

        [HttpGet("{id}")]
        public Movie GetSingleMovie(int id)
        {
            Movie movie = dal.GetMovieById(id);
            return movie; 
        }

        [HttpGet("random")]
        public Movie GetRandomMovie(string category = null)
        {

            if (category == null)
            {
                IEnumerable<Movie> movies = dal.GetMoviesAll();
                var rng = new Random();
                int random = rng.Next(movies.Count());
                Movie movie = dal.GetMovieByRow(random);                

                return movie; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                IEnumerable<Movie> movies = dal.GetMoviesByCategory(category);
                var rng = new Random();
                int random = rng.Next(movies.Count());
                Movie movie = movies.ToArray<Movie>()[random];
                
                return movie;
            }
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string category = null)
        {
            if (category == null)
            {
                IEnumerable<Movie> Movies = dal.GetMoviesAll();
                return Movies; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                IEnumerable<Movie> Movies = dal.GetMoviesByCategory(category);
                return Movies;
            }
        }

        [HttpGet("categories")]
        public string[] GetCategories()
        {
            return dal.GetMovieCategories();
        }

        [HttpPost]
        public Object Post(Movie m)
        {
            int newId = dal.CreateMovie(m);

            if (newId < 0)
            {
                return new { success = false };
            }
            return new { success = true, id = newId };
        }

    }
}