using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_kino
{
    public class MovieInfoProxy
    {
        private readonly TmdbService _tmdbService;
        private readonly OmdbService _omdbService;
        private readonly Dictionary<string, string> _cache;

        public MovieInfoProxy(TmdbService tmdbService, OmdbService omdbService)
        {
            _tmdbService = tmdbService;
            _omdbService = omdbService;
            _cache = new Dictionary<string, string>();
        }

        public string GetMovieInfo(string title)
        {
            if (_cache.ContainsKey(title))
            {
                return _cache[title];
            }

            string result = _tmdbService.GetMovieInfo(title);
            if (result != null)
            {
                _cache[title] = result;
                return result;
            }

            result = _omdbService.GetMovieInfo(title);
            if (result != null)
            {
                _cache[title] = result;
                return result;
            }

            return null;
        }
    }
}
