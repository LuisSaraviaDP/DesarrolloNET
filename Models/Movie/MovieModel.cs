using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace EvaTecMVC.Models.Movie
{
    /// <summary>
    /// Clase que representa un modelo de película.
    /// </summary>

    public class MovieModel
    {
        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }

        [JsonProperty("release_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ReleaseDate { get; set; }

        public string Title { get; set; }
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public bool MatchesGenre(int genreFilter)
        {
            return GenreIds.Contains(genreFilter);
        }

        public bool ContainsTitle(string titleFilter)
        {
            return string.IsNullOrEmpty(titleFilter) || Title?.IndexOf(titleFilter, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public bool ContainsOverview(string overviewFilter)
        {
            return string.IsNullOrEmpty(overviewFilter) || Overview?.IndexOf(overviewFilter, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
