using Based.DataAccess.Interfaces;
using Based.DataAccess.Models;
using SharpRepository.Repository;

namespace Based.DataAccess
{
    public class DetailRepository : ConfigurationBasedRepository<Detail, int>, IDetailRepository
    {
    }
}