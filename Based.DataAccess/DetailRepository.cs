using Based.DataAccess.Contexts;
using Based.DataAccess.Interfaces;
using Based.DataAccess.Models;
using SharpRepository.EfRepository;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace Based.DataAccess
{
    public class DetailRepository : ConfigurationBasedRepository<Detail, int>, IDetailRepository
    {
        private static SharpRepositoryConfiguration GetConfig()
        {
            var config = new SharpRepositoryConfiguration();
            
            config.AddRepository(new EfRepositoryConfiguration("efRepository", "Data Source=DEV\\DEVELOPMENT; Initial Catalog=DemoDb; Integrated Security=True;", typeof(DemoDbContext)));

            return config;
        }

        public DetailRepository(): base(GetConfig())
        {            
        }
    }
}