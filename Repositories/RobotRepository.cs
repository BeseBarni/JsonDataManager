using Application.Contracts.Repositories;
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

    }
}
