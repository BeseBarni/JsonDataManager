using Application.Contracts.Services;
using Data.Contracts.Models;
using System;
using System.Text.Json;
using System.Xml.Linq;

namespace Services
{
    public class WageService : IWageService
    {
        
        private const string FILE_PATH = @"wages.json";


        public async Task SaveWages(List<Wage> wages)
        {
            await using FileStream createStream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(createStream, wages);
        }
        
        public async Task<List<Wage>> GetWagesAsync()
        {
            await using FileStream openStream = File.OpenRead(FILE_PATH);
            return await JsonSerializer.DeserializeAsync<List<Wage>>(openStream);
        }

        public async Task UpdateWagesAsync(List<Wage> wages)
        {
            wages.ForEach(p => p.Gross = p.Gross * 1.1);
            await using FileStream createStream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(createStream, wages);
        }
    }
}
