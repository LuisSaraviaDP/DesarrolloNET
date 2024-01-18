using EvaTecMVC.Models.Movie;

namespace EvaTecMVC.Models.MovieApiResponse
{
    /// <summary>
    /// Clase que representa la respuesta de la API de películas.
    /// </summary>
    public class MovieApiResponse
    {
        public int Page { get; set; }
        public List<MovieModel> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
