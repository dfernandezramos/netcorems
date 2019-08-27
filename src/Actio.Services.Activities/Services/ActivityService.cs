using Actio.Common.Exceptions;
using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        readonly IActivityRepository _activityRepository;
        readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);

            if (activityCategory == null)
            {
                throw new ActioException("category_not_found", $"Category: '{name}' was not found");
            }

            var activity = new Activity(id, activityCategory, userId, name, description, createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}
