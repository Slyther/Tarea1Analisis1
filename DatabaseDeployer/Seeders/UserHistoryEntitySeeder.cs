using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace DatabaseDeployer.Seeders
{
    class UserHistoryEntitySeeder : IDataSeeder
    {
        readonly ISession _session;
        public UserHistoryEntitySeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
            var hist = new UserHistoryEntity
            {
                ProjectId = 1,
                UserType = "Guest",
                Goal = "to be able to open the website",
                Reason = "I can navigate it"
            };
            var hist2 = new UserHistoryEntity
            {
                ProjectId = 1,
                UserType = "User",
                Goal = "to be able to send messages to other users",
                Reason = "I can communicate through the website"
            };
            var hist3 = new UserHistoryEntity
            {
                ProjectId = 1,
                UserType = "Administrator",
                Goal = "to be able to ban users",
                Reason = "I can moderate the website"
            };
            var hist4 = new UserHistoryEntity
            {
                ProjectId = 2,
                UserType = "Administrator",
                Goal = "be able to post an entry on the website",
                Reason = "I can have a blog"
            };
            var hist5 = new UserHistoryEntity
            {
                ProjectId = 2,
                UserType = "Administrator",
                Goal = "be able to archive an entry",
                Reason = "it can no longer be seen by blog readers"
            };
            var hist6 = new UserHistoryEntity
            {
                ProjectId = 3,
                UserType = "Project Developer",
                Goal = "be able to write code",
                Reason = "I can develop an app"
            };
            var hist7 = new UserHistoryEntity
            {
                ProjectId = 3,
                UserType = "Project Leader",
                Goal = "be able to check Developer logs",
                Reason = "I can keep track of the Developers' work"
            };
            _session.Save(hist);
            _session.Save(hist2);
            _session.Save(hist3);
            _session.Save(hist4);
            _session.Save(hist5);
            _session.Save(hist6);
            _session.Save(hist7);
        }
    }
}
