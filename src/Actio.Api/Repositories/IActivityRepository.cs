using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    public interface IActivityRepository
    {
        Task AddAsync(Activiy model);
    }
}
