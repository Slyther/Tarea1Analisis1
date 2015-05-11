using Domain.Entities;
using Domain.Services;
using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace DatabaseDeployer.Seeders
{
    class UserSeeder : IDataSeeder
    {
        readonly ISession _session;

        public UserSeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
            var account = new User
            {
                Email = "admin@Synergy.com",
                Name = "Administrator",
                Password = "somepassword",
                IsAdmin = true
            };
            PasswordEncryptionService.Encrypt(account);
            _session.Save(account);
        }
    }
}
