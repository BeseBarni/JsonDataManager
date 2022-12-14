
using Application.Contracts.Services;
using Data.Contracts.Models.Robot;
using System.Net.Http.Json;
using System.Text.Json;

namespace Services
{
    public class RobotService : IRobotService
    {
        private const string ROBOT_PATH = @"https://randomuser.me/api/";
        private const string ROBOT_PICTURE_PATH = @"https://robohash.org/";
        private readonly HttpClient _http;
        public RobotService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Robot> GetRobotAsync()
        {
            var r = new Random();
            try
            {
                var response = await _http.GetAsync(ROBOT_PATH);
                var output = await response.Content.ReadFromJsonAsync<RobotResult>();
                output.Results[0].PicturePath = ROBOT_PICTURE_PATH + r.Next();
                return output.Results[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
