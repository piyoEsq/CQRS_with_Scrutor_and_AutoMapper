using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Models;
using Sample.Services.User.Commands;
using Sample.Services.User.Queries;

namespace Sample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMapper _mapper;
        private readonly ICreateUserCommandHandler _createUserCommandHandler;
        private readonly IGetUserByIdQueryHandler _getUserByIdQueryHandler;

        public Worker(ILogger<Worker> logger,
                      IMapper mapper,
                      ICreateUserCommandHandler createUserCommandHandler,
                      IGetUserByIdQueryHandler getUserByIdQueryHandler)
        {
            _logger = logger;
            _mapper = mapper;
            _createUserCommandHandler = createUserCommandHandler;
            _getUserByIdQueryHandler = getUserByIdQueryHandler;
        }

#pragma warning disable
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Command
            var userId = UserId.Create();
            var userName = UserName.Create("hoge", "fuga");
            var user = User.Create(userId, userName);
            _createUserCommandHandler.Handle(new CreateUserCommand(user));

            // Query
            GetUserByIdResponse response;
            response = _getUserByIdQueryHandler.Handle(new GetUserByIdRequest { UserId = userId });
            response = _getUserByIdQueryHandler.Handle(new GetUserByIdRequest { UserId = userId });

            // Mapping
            var responsedUser = _mapper.Map<GetUserByIdResponse, User>(response);
            _logger.LogInformation(responsedUser.Id.Id.ToString());
            _logger.LogInformation(responsedUser.Name.FullName);
        }
#pragma warning restore
    }
}
