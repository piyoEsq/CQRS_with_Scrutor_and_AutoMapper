using Sample.Interfaces.Queries;
using Sample.Models;

namespace Sample.Services.User.Queries
{
    public class GetUserByIdRequest : IRequest
    {
        public UserId UserId { get; set; }
    }
}