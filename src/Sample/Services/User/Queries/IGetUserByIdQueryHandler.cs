using Sample.Interfaces.Queries;

namespace Sample.Services.User.Queries
{
    public interface IGetUserByIdQueryHandler : IQueryHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
         
    }
}