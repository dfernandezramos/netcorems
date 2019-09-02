using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        readonly IBusClient _busClient;
        readonly IActivityService _activityService;
        readonly ILogger _logger;

        public CreateActivityHandler(IBusClient busClient, IActivityService activityService, ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Name}");

            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));

                return;
            }
            catch (ActioException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "error", ex.Message));
                Console.WriteLine(ex.Message);
            }

        }
    }
}
