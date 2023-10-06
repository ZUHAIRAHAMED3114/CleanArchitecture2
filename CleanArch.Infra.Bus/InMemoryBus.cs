using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Core.Command;

namespace CleanArch.Infra.Bus
{
    public class InMemoryBus:IMediatorHandler
    { 
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T Command) where T : Command {
            return _mediator.Send(Command);
        }
    }
}
