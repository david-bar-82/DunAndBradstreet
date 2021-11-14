using System;
using System.Collections.Generic;
using static Dun_and_bradstreet.Models.DuckDuckGoResponse;

namespace Dan_and_bradstreet.Models
{
    public class SearchModelResponse
    {
        public List<QueryResult> SearchResults { get; set; }
        public SearchModelResponse()
        {           
        }
    }
}
