using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dz_kino
{
    public class OmdbService : MdbService
    {
        public OmdbService(string apiKey) : base(apiKey) { }
        public override string GetMovieInfo(string title)
        {
            using (var client = new HttpClient())
            {
                // Поиск в OMDB API
                return "Какой-то фильм";
            }
        }
    }
}
