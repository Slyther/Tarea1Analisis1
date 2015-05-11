using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace DatabaseDeployer.Seeders
{
    class ProjectEntitySeeder : IDataSeeder
    {
        readonly ISession _session;
        public ProjectEntitySeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
            var proj = new ProjectEntity
            {
                ProjectName = "Social Network Project",
                ProjectDescription = "A social network that is to be designed",
                UserId = 1
            };
            var proj2 = new ProjectEntity
            {
                ProjectName = "Blog Project",
                ProjectDescription = "A Blog that is to be designed",
                UserId = 1
            };
            var proj3 = new ProjectEntity
            {
                ProjectName = "IDE Project",
                ProjectDescription = "A Programming IDE that is to be designed",
                UserId = 1
            };
            _session.Save(proj);
            _session.Save(proj2);
            _session.Save(proj3);
        }
    }
}
