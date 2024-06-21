using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dz_kino
{
    public class TmdbService : MdbService
    {
        public TmdbService(string apiKey) : base(apiKey) { }
        public override string GetMovieInfo(string title)
        {
            using (var client = new HttpClient())
            {
                // Поиск в TMDB API
                return "Какой-то фильм";
            }
        }
    }
}
