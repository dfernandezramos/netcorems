﻿using Actio.Services.Identity.Domain.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        public async Task<User> GetAsync(Guid id)
            => await Collection.AsQueryable()
                               .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await Collection.AsQueryable()
                               .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");
    }
}
