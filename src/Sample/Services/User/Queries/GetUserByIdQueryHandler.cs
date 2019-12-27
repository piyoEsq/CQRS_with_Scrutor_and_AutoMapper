using Microsoft.Extensions.Logging;
using Sample.Interfaces.Repositories;
using Sample.Services.User.Queries;

namespace Sample.GenericHost.Services.User.Queries
{
    public class GetUserByIdQueryHandler : IGetUserByIdQueryHandler
    {
        private ILogger<GetUserByIdQueryHandler> _logger;
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger,
                                       IUserRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }
        public GetUserByIdResponse Handle(GetUserByIdRequest input)
        {
            var user = _repository.GetById(input.UserId);
            return new GetUserByIdResponse() { AbsolutelyUserId = user.Id, MaybeUserName = user.Name };
        }
    }
}