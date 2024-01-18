using System;
using EvaTecMVC.Models;

namespace EvaTecMVC.Helpers
{
    public static class EnumHelper
    {
        public static string GetGenreName(int genreId)
        {
            
            var genre = (Genre)genreId;

            switch (genre)
            {
                case Genre.Action:
                    return "Action";
                case Genre.Adventure:
                    return "Adventure";
                case Genre.Animation:
                    return "Animation";
                case Genre.Comedy:
                    return "Comedy";
                case Genre.Crime:
                    return "Crime";
                case Genre.Documentary:
                    return "Documentary";
                case Genre.Drama:
                    return "Drama";
                case Genre.Family:
                    return "Family";
                case Genre.Fantasy:
                    return "Fantasy";
                case Genre.History:
                    return "History";
                case Genre.Horror:
                    return "Horror";
                case Genre.Music:
                    return "Music";
                case Genre.Mystery:
                    return "Mystery";
                case Genre.Romance:
                    return "Romance";
                case Genre.ScienceFiction:
                    return "Science Fiction";
                case Genre.TVMovie:
                    return "TV Movie";
                case Genre.Thriller:
                    return "Thriller";
                case Genre.War:
                    return "War";
                case Genre.Western:
                    return "Western";
                default:
                    return "Unknown";
            }
        }
    }
}
