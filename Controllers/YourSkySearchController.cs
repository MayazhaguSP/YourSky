using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using YourSky.Models;

namespace YourSky.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YourSkySearchController : ControllerBase
    {

        private readonly ILogger<YourSkySearchController> _logger;

        public YourSkySearchController(ILogger<YourSkySearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<YourSkySearch>> Get()
        {
            try
            {
                List<YourSkySearch> list = new List<YourSkySearch>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetAllAlbums();
                return list.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
