using System;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonDataManager.Data
{
    public class WageService
    {
        public const double TAX_KEY = 0.665;
        private const string FILE_PATH = @"wages.json";
        public List<Wage> Wages { get; set; }
        public async Task GenerateWagesAsync(int count)
        {
            List<Wage> wages = new List<Wage>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                double wage = r.Next(200000, 5500000);
                wages.Add(new Wage(wage,TAX_KEY));
            }
            Wages = wages;
            await using FileStream createStream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(createStream, wages);
        }

        public async Task<List<Wage>> GetWagesAsync()
        {
            await using FileStream openStream = File.OpenRead(FILE_PATH);
            return await JsonSerializer.DeserializeAsync<List<Wage>>(openStream);
        }

        public async Task UpdateWagesAsync()
        {
            Wages.ForEach(p => p.Gross = p.Gross * 1.1);
            await using FileStream createStream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(createStream, Wages);
        }
    }
}
