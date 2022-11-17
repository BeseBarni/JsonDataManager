using JsonDataManager.Data.Models.Robot;
using System.Text.Json;

namespace JsonDataManager.Data
{
    public class RobotService
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
