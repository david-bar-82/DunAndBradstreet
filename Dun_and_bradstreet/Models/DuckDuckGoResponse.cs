using System;
using System.Collections.Generic;
using Dan_and_bradstreet.Models;

namespace Dun_and_bradstreet.Models
{
    public class DuckDuckGoResponse
    {
        public List<RelatedTopicsObj> RelatedTopics { get; set; }
        public DuckDuckGoResponse()
        {
        }

        public class RelatedTopicsObj : QueryResult
        {
            public string Name { get; set; }
            public List<QueryResult> Topics { get; set; }

        }        
    }
}
