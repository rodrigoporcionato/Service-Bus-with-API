using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Infra.Bus;

namespace Talent.Infra.Events
{
    [MessageQueue("TesteDispacth", "direct")]
    public class DispatchAcceptEvent: IntegrationEvent
    {
        public string RequestNumber { get; set; }

        public string CarType { get; set; }

        public string Name { get; set; }

    }
}
