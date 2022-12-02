using Application.Contracts.Services;
using Data.Contracts.Models;

namespace Application.Contracts.BusinessLogic
{
    public interface IWageBusinessLogic
    {
        List<Wage> Wages { get; set; }
        Task UpdateWagesAsync();
        Task<List<Wage>> GetWagesAsync();
        Task GenerateWagesAsync(int count);
    }
}