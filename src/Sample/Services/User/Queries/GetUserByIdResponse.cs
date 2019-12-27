using System;
using Sample.Interfaces.Queries;
using Sample.Models;

namespace Sample.Services.User.Queries
{
    public class GetUserByIdResponse : IResponse<GetUserByIdRequest>
    {
        public UserId AbsolutelyUserId { get; set; }
        public UserName MaybeUserName { get; set; }
    }
}