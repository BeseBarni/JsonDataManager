using System;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonDataManager.Data
{
    public class WageService
    {
        public const double TAX_KEY = 0.665;
        private const string FILE_PATH = @"wages.json";
        public async Task GenerateWagesAsync(int count)
        {
            List<Wage> wages = new List<Wage>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                double wage = r.Next(200000, 5500000);
                wages.Add(new Wage(wage, wage * TAX_KEY));
            }
            await using FileStream createStream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(createStream, wages);
        }

        public async Task<List<Wage>> GetWagesAsync()
        {
            await using FileStream openStream = File.OpenRead(FILE_PATH);
            return await JsonSerializer.DeserializeAsync<List<Wage>>(openStream);
        }
    }
}
