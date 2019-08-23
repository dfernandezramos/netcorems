using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Repositories
{
    interface IActivityREpository
    {
        Task<Activity> GetAsync(Guid id);

        Task AddAsync(Activity category);
    }
}
