using System;

namespace app.console.searchengine
{
  public class Bootstrap
  {
    public static void main(string[] args)
    {

        var rs = new ResultListener();
        var il = new ImageListener();

        Search.run(new Search.SearchOptions()
            {
                url = new Uri("http://www.amazon.ca/s/ref=nb_sb_ss_i_0_11?url=search-alias%3Daps&field-keywords=programming&sprefix=programming%2Caps%2C191&rh=i%3Aaps%2Ck%3Aprogramming"), 
                search_criteria = ""
            },
            rs.parse_result,
            il.parse_images);
    } 
  }
}