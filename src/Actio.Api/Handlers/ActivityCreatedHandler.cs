using Actio.Api.Repositories;
using Actio.Common.Events;
using System;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityCreatedHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task HandleAsync(ActivityCreated @event)
        {
            await _activityRepository.AddAsync();
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
