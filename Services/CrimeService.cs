
using Application.Contracts.Services;
using Data.Contracts.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace Services
{
    public class CrimeService : ICrimeService
    {
        private const string CRIME_PATH = @"https://math.uni-pannon.hu/~lipovitsa/cs/data/crime.json";
        private HttpClient _http;
        public CrimeService(HttpClient http)
        {
            _http = http;

        }

        public async Task<List<Crime>> GetCrimesAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Crime>>(CRIME_PATH);
            return result;
        }
    }
}
