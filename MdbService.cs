using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_kino
{
    public abstract class MdbService
    {
        protected string _apiKey;
        public MdbService(string apiKey)
        {
            _apiKey = apiKey;
        }
        public abstract string GetMovieInfo(string title);
    }
}
