using Application.Contracts.BusinessLogic;
using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Data.Contracts.Models;
using Data.Contracts.Models.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class RobotBusinessLogic : IRobotBusinessLogic
    {
        private ICrimeService crime;
        private IRobotService robot;
        private IRobotRepository robotRepo;
        public RobotBusinessLogic(IRobotService robot, ICrimeService crime, IRobotRepository robotRepository)
        {
            this.robot = robot;
            this.crime = crime;
            this.robotRepo = robotRepository;
        }
        public Task<List<Crime>> GetCrimesAsync()
        {
            return crime.GetCrimesAsync();
        }

        public Task<Robot> GetRobotAsync()
        {
            return robot.GetRobotAsync();
        }

        public void SaveRobot(Domain.ROBOT.Robots robot)
        {
            robotRepo.SaveRobot(robot);
        }
    }
}
