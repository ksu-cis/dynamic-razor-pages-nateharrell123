using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        static MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        /// <summary>
        /// Searches the database for matching movies
        /// </summary>
        /// <param name="terms">The terms to search for</param>
        /// <returns>A collection of movies</returns>
        public static IEnumerable<Movie> Search(string terms)
        {
            if (terms == null) return All;
            List<Movie> results = new List<Movie>();

            // return each movie in the database containing the terms substring
            foreach (Movie movie in All)
            {
                if (movie.Title.Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                {
                    results.Add(movie);
                }
            }

        }

        /// <summary>
        /// Gets all the movies in the database
        /// </summary>
        public static IEnumerable<Movie> All { get { return movies; } }
    }
}
