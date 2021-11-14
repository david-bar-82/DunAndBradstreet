using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dan_and_bradstreet.Models;
using Dan_and_bradstreet.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Dan_and_bradstreet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsApi")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string query)
        {
            if (string.IsNullOrEmpty(query))
                return BadRequest();
            var results = await searchService.GetSearchResults(query);
            return Ok(new SearchModelResponse() { SearchResults = results});
         
        }
    }
}
