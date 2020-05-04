using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The current search terms 
        /// </summary>
        public string SearchTerms { get; set; }
        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// Gets the search results for display on the page
        /// </summary>
        public void OnGet()
        {
            /*
            SearchTerms = Request.Query["SearchTerms"];
            MPAARatings = Request.Query["MPAARatings"];
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            */

            // Search movie titles for the search terms.
            Movies = MovieDatabase.All;
            if(SearchTerms != null)
            {
                Movies = Movies.Where(movie => 
                movie.Title != null && 
                movie.Title.Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase));
            }

            // Filter by MPAA rating
            if(MPAARatings != null && MPAARatings.Length != 0)
            {
                // Take list of movies and shorten it by 
                Movies = Movies.Where(movie => 
                movie.MPAARating != null && MPAARatings.Contains(movie.MPAARating));
            }
        }
    }
}
