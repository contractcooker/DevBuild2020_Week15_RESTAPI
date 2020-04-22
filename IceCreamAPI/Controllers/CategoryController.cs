using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IDAL dal;

        public CategoryController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpGet]
        public string[] GetCategories()
        {
            return dal.GetMovieCategories();
        }

    }
}