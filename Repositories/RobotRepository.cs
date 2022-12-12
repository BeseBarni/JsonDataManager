using Application.Contracts.Repositories;
using Data.Contracts.Models.Robot;
using Domain.ROBOT;

namespace Repositories
{
    public class RobotRepository : BaseRepository<ROBOTREPO>, IRobotRepository
    {
        protected override ROBOTREPO CreateNewContext()
        {
            var ctx = new ROBOTREPO();
            return ctx;
        }
        public void SaveRobot(Robots robot)
        {
            using (Ctx = CreateNewContext())
            {
                try
                {
                    Ctx.Robots.Add(robot);
                    Ctx.SaveChanges();
                }
                catch (Exception)
                {
                }
            }

        }

        public int GetRobotCount()
        {
            using (Ctx = CreateNewContext())
            {
                try
                {
                    return Ctx.Robots.Count();
                    
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
