using Application.Contracts.Services;
using Domain.ROBOT;

namespace Application.Contracts.BusinessLogic
{
    public interface IRobotBusinessLogic : IRobotService, ICrimeService
    {
        void SaveRobot(Robots robot);
    }
}