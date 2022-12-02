using Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IWageService
    {
        
        Task UpdateWagesAsync(List<Wage> wages);
        Task<List<Wage>> GetWagesAsync();
        Task SaveWages(List<Wage> wages);
    }
}
