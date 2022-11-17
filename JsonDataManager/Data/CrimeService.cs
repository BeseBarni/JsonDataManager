using JsonDataManager.Data.Models;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace JsonDataManager.Data
{
    public class CrimeService
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
