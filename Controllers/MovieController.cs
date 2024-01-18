using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using EvaTecMVC.Models;
using EvaTecMVC.Models.Movie;
using EvaTecMVC.Models.MovieApiResponse;
using Newtonsoft.Json.Serialization;

[Authorize]
public class MovieController : Controller
{
    private const string ApiKey = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI5NTVhNDI4NDM3NWRhZGQ3MTdhMjI1M2RmMzlhYjMxMSIsInN1YiI6IjY1YTBiMmRiZGI0ZWQ2MDEyYzVmNzRiMSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.KdNBYPA-dFTcs1OwpsxpFxT5gGd_Z44knXzA2LzR6Ds";
    private const string ApiUrl = "https://api.themoviedb.org/3/discover/movie";
    private const int PageSize = 10;

    public async Task<IActionResult> Index(int? page, int? genreFilter, string titleFilter, string overviewFilter)
    {
        int pageNumber = page ?? 1;

        var client = new RestClient(ApiUrl);
        var request = new RestRequest("");

        ConfigureApiRequest(request, pageNumber, genreFilter);

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            // Deserializar la respuesta JSON a MovieApiResponse
            var movieApiResponse = JsonConvert.DeserializeObject<MovieApiResponse>(response.Content, jsonSerializerSettings);

            // Aplicar filtros a los resultados de la API
            ApplyFilters(movieApiResponse, genreFilter, titleFilter, overviewFilter);

            // Paginar la lista de resultados
            var paginatedList = movieApiResponse.Results.ToPagedList(pageNumber, PageSize);

            ViewBag.CurrentGenreFilter = genreFilter;
            ViewBag.CurrentTitleFilter = titleFilter;
            ViewBag.CurrentOverviewFilter = overviewFilter;

            return View(paginatedList);
        }
        else
        {
            return View(new List<MovieModel>().ToPagedList(1, PageSize));
        }
    }

    private void ConfigureApiRequest(RestRequest request, int pageNumber, int? genreFilter)
    {
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {ApiKey}");
        request.AddParameter("include_adult", false);
        request.AddParameter("include_video", false);
        request.AddParameter("language", "en-US");
        request.AddParameter("page", pageNumber);
        request.AddParameter("sort_by", "popularity.desc");

        if (genreFilter.HasValue)
        {
            request.AddParameter("with_genres", genreFilter.Value);
        }
    }

    private void ApplyFilters(MovieApiResponse movieApiResponse, int? genreFilter, string titleFilter, string overviewFilter)
    {
        if (genreFilter.HasValue)
        {
            movieApiResponse.Results = movieApiResponse.Results.Where(movie => movie.MatchesGenre(genreFilter.Value)).ToList();
        }

        movieApiResponse.Results = movieApiResponse.Results.Where(movie => movie.ContainsTitle(titleFilter)).ToList();
        movieApiResponse.Results = movieApiResponse.Results.Where(movie => movie.ContainsOverview(overviewFilter)).ToList();
    }
}
