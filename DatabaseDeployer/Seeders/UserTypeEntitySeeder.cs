using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace DatabaseDeployer.Seeders
{
    class UserTypeEntitySeeder : IDataSeeder
    {
        readonly ISession _session;
        public UserTypeEntitySeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
            var ustype = new UserTypeEntity
            {
                ProjectId = 1,
                UserTypeName = "Guest"
            };
            var ustype2 = new UserTypeEntity
            {
                ProjectId = 1,
                UserTypeName = "User"
            };
            var ustype3 = new UserTypeEntity
            {
                ProjectId = 1,
                UserTypeName = "Administrator"
            };
            var ustype4 = new UserTypeEntity
            {
                ProjectId = 2,
                UserTypeName = "Administrator"
            };
            var ustype5 = new UserTypeEntity
            {
                ProjectId = 3,
                UserTypeName = "Project Developer"
            };
            var ustype6 = new UserTypeEntity
            {
                ProjectId = 3,
                UserTypeName = "Project Leader"
            };
            _session.Save(ustype);
            _session.Save(ustype2);
            _session.Save(ustype3);
            _session.Save(ustype4);
            _session.Save(ustype5);
            _session.Save(ustype6);
        }
    }
}
