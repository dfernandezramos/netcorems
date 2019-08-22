﻿using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;
using System.Reflection;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                                                ctx => ctx.UseConsumerConfiguration(cfg => cfg.FromDeclaredQueue(Queue => Queue.WithName(GetQueueName<TCommand>())))
                                                );
        }

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                                              ctx => ctx.UseConsumerConfiguration(cfg => cfg.FromDeclaredQueue(Queue => Queue.WithName(GetQueueName<TEvent>())))
                                              );
        }

        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}