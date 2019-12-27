using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sample.Interfaces.Commands;
using Sample.Interfaces.Repositories;
using Sample.Models;

namespace Sample.Services.User.Commands
{
    public class CreateUserCommandHandler : ICreateUserCommandHandler
    {
        private ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
                                        IUserRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }
        public void Handle(CreateUserCommand input)
        {
            _logger.LogInformation("Handled by CreateUserCommandHandler");
            _repository.Add(input.User);
        }
    }
}