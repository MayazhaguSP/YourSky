using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourSky.Models;

namespace YourSky.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YourSkySearchController : ControllerBase
    {

        private readonly ILogger<YourSkySearchController> _logger;

        public YourSkySearchController(ILogger<YourSkySearchController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<YourSkySearch>> Search([FromBody] SearchFilter data)
        {
            try
            {
                List<YourSkySearch> list = new List<YourSkySearch>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetAllSearchFilter(data);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("location")]
        public async Task<IEnumerable<YourskyLocation>> GetLocation()
        {
            try
            {
                List<YourskyLocation> list = new List<YourskyLocation>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetLocation();
                return list;
                // return JsonSerializer.Serialize(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("university")]
        public async Task<IEnumerable<YourskyUniversity>> GetUniversity()
        {
            try
            {
                List<YourskyUniversity> list = new List<YourskyUniversity>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetUniversity();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("intakes")]
        public async Task<IEnumerable<YourskyIntakes>> GetIntakes()
        {
            try
            {
                List<YourskyIntakes> list = new List<YourskyIntakes>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetIntakes();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("educationlevel")]
        public async Task<IEnumerable<YourskyEducationlevel>> GetEducationlevel()
        {
            try
            {
                List<YourskyEducationlevel> list = new List<YourskyEducationlevel>();
                SearchContext context = HttpContext.RequestServices.GetService(typeof(SearchContext)) as SearchContext;

                list = context.GetEducationlevel();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
