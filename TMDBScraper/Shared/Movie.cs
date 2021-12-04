using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDBScraper.Shared
{
    public class Movie
    {
        public Boolean adult { get; set; }
        public string backdrop_path { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public string title { get; set; }
        public Boolean video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

    }
}
