﻿using Actio.Services.Activities.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Repositories
{
    interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);

        Task AddAsync(Activity category);
    }
}