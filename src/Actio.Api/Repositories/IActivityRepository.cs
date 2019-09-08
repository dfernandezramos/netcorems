using Actio.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);

        Task AddAsync(Activity activity);

        Task<IEnumerable<Activity>> BrowseAsync(Guid userID);
    }
}
