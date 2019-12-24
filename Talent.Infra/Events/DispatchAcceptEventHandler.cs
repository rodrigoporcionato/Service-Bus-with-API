using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Infra.Bus;

namespace Talent.Infra.Events
{
    public class DispatchAcceptEventHandler : IIntegrationEventHandler<DispatchAcceptEvent>
    {
        private readonly ILogger<DispatchAcceptEventHandler> _logger;

        //public DispatchAcceptEventHandler(ILogger<DispatchAcceptEventHandler> logger)
        //{
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        public async Task Handle(DispatchAcceptEvent @event)
        {
            //_logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            await Task.Run(() => _logger.LogInformation("do something"));

        }

    }
}
