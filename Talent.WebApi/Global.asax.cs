using Autofac;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Talent.Infra.Bus;
using Talent.Infra.Events;
using Talent.Infra.RabbitMQ;

namespace Talent.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private ILifetimeScope _AutoFac { get; set; }

       
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            var loggerConnection = loggerFactory.CreateLogger<DefaultRabbitMQPersistentConnection>();
            
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true,
                UserName = "guest",
                Password = "guest"
            };


            DefaultRabbitMQPersistentConnection rabbitmqConnection = new DefaultRabbitMQPersistentConnection(factory, loggerConnection, 5);

            if (!rabbitmqConnection.IsConnected)
            {
                rabbitmqConnection.TryConnect();
            }
            
            var logger = loggerFactory.CreateLogger<EventBusRabbitMQ>();
            
            //DI
            var builder = new ContainerBuilder();
            builder.RegisterType<DispatchAcceptEventHandler>().InstancePerLifetimeScope();            

            var eventBus = new EventBusRabbitMQ(rabbitmqConnection, logger, builder.Build(), 5);

            //Subscribes
            eventBus.Subscribe<DispatchAcceptEvent, DispatchAcceptEventHandler>();


            
        }
    }
}
