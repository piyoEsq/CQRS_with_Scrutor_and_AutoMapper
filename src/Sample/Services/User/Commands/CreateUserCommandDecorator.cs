using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sample.Interfaces.Commands;

namespace Sample.Services.User.Commands
{
    public class CreateUserCommandDecorator : ICreateUserCommandHandler
    {
        private readonly ICreateUserCommandHandler handler;
        private readonly ILogger<CreateUserCommandHandler> logger;
        public CreateUserCommandDecorator(ILogger<CreateUserCommandHandler> logger, ICreateUserCommandHandler handler)
        {
            this.logger = logger;
            this.handler = handler;
        }
        public void Handle(CreateUserCommand input)
        {
            logger.LogInformation("Pre Processor of ICreateUserCommandHandler");
            handler.Handle(input);
            logger.LogInformation("Post Processor of ICreateUserCommandHandler");
        }
    }
}