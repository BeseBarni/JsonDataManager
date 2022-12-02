using Application.Contracts.BusinessLogic;
using Application.Contracts.Services;
using Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class WageBusinessLogic : IWageBusinessLogic
    {
        public const double TAX_KEY = 0.665;

        private IWageService wageService;

        public WageBusinessLogic(IWageService wageService)
        {
            this.wageService = wageService;
        }

        public List<Wage> Wages { get; set; }
        public async Task GenerateWagesAsync(int count)
        {
            List<Wage> wages = new List<Wage>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                double wage = r.Next(200000, 5500000);
                wages.Add(new Wage(wage, TAX_KEY));
            }
            Wages = wages;
            await wageService.SaveWages(wages);
        }

        public async Task<List<Wage>> GetWagesAsync()
        {
            return await wageService.GetWagesAsync();
        }

        public async Task UpdateWagesAsync()
        {
            await wageService.UpdateWagesAsync(Wages);
        }
    }
}
