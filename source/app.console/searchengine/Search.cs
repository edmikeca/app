using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace app.console.searchengine
{
    public class Search
    {
        public event FoundResult result_found = delegate
        {

        };


        public static void run(SearchOptions options, params FoundResult[] listeners)
        {
            var finder = new Search();
            foreach (var listener in listeners) finder.result_found += listener;
            finder.find(options);
        }


        public void find(SearchOptions options)
        {
            //TODO: Build correct URL

            var client = new HttpClient();
            var resp = client.GetAsync(options.url).Result;
            resp.EnsureSuccessStatusCode();
            var rs = resp.Content.ReadAsStringAsync();


//            Console.WriteLine(rs);

            on_search_found(new FoundResultArgs());

        }


        protected void on_search_found(FoundResultArgs args)
        {
            result_found(this, args);
        }



        public class SearchOptions
        {
            public Uri url { get; set; }
            public string search_criteria { get; set; }
        }
    }
}
