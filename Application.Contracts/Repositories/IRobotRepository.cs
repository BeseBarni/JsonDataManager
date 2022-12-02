using Domain.ROBOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repositories
{
    public interface IRobotRepository
    {
        void SaveRobot(Robots robot);
    }
}
