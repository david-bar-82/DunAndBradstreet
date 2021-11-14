using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dan_and_bradstreet.Models;
using Dun_and_bradstreet.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Dan_and_bradstreet.Services
{
    public interface ISearchService
    {
        Task<List<QueryResult>> GetSearchResults(string query);
    }

    public class SearchService : ISearchService
    {
        private readonly AppSettings settings;

        public SearchService(IOptions<AppSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<List<QueryResult>> GetSearchResults(string query)
        {
            var response = new List<QueryResult>();
            using (var client = new HttpClient())
            {
                var results = await client.GetAsync(string.Format(settings.SearchUrl, query));
                var jsonString = await results.Content.ReadAsByteArrayAsync();
                var jsonResult = JsonConvert.DeserializeObject<DuckDuckGoResponse>(System.Text.Encoding.Default.GetString(jsonString));
                response.AddRange(jsonResult.RelatedTopics.Where(r => r.FirstURL != null).Select(r => new QueryResult() { FirstURL = r.FirstURL, Text= r.Text}));              
                response.AddRange(jsonResult.RelatedTopics.Where(r => r.Topics != null).SelectMany(r=>r.Topics).ToList());               
                return response;
            }
        }
    }
}
