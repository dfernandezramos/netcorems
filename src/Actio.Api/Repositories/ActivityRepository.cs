using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Api.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userID)
            => await Collection.AsQueryable().Where(x => x.UserId == userID).ToListAsync();

        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activities");
    }
}
